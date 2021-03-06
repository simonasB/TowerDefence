﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.Bullets;
using TowerDefence.Database.Entities;
using TowerDefence.Minions;
using TowerDefence.State;
using TowerDefence.Towers;
using TowerDefence.Towers.Decorator;
using TowerDefence.Visitor;
using TowerDefence.Memento;

namespace TowerDefence.Core {
    public class Game {
        public bool Running { get; set; }
        public int Points { get; set; }
        public int Life { get; set; }
        public decimal Money { get; set; }
        public int NextLevelCounterSeconds { get; set; }
        protected int _designatedNextLevelCounterSeconds { get; set; }
        public Map Map { get; set; }

        System.Windows.Forms.Timer Clock = new System.Windows.Forms.Timer();

        public List<Minion> Enemies { get; set; }
        public List<Bullet> Bullets { get; set; }
        private List<AbstractTower> _towers;
        public List<AbstractTower> TowersToAdd { get; set; }
        public List<GameLevel> Levels { get; set; }

        public AbstractTower SelectedTower { get; set; }

        public List<GameInfo> GameInfos { get; set; }

        private int _currentLevel = 1;
        private int _destroyedEnemies = 0;
        private bool _decorated;
        public GameState GameState { get; set; }

        public IVisitor AmountCalculatorVisitor { get; set; }
        public int ArcherTowersAmount { get; set; }
        public int CannonTowersAmount { get; set; }

        public Game(int nextWaveCounterSec) {
            _designatedNextLevelCounterSeconds = nextWaveCounterSec;
            NextLevelCounterSeconds = nextWaveCounterSec;

            GameState = new NotStartedState(this);

            Clock.Interval = 1000;
            Clock.Start();
            Clock.Tick += Timer_Tick;

            Map = new Map();

            Enemies = new List<Minion>();
            Bullets = new List<Bullet>();
            _towers = new List<AbstractTower>();
            TowersToAdd = new List<AbstractTower>();
            Levels = new List<GameLevel>();
            GameInfos = new List<GameInfo>();
            AmountCalculatorVisitor = new TowersAmountCalculatorVisitor();

            ArcherTowersAmount = 0;
            CannonTowersAmount = 0;
        }

        public void Timer_Tick(object sender, EventArgs eArgs) {
            if (Running) {
                NextLevelCounterSeconds--;
            }
        }

        public void Update(bool force)
        {
            AmountCalculatorVisitor.TotalMoney = 0;
            if (!Running && !force)
                return;

            if (NextLevelCounterSeconds == 0) {             
                
                SendNextLevel();
            }

            foreach (var item in Levels) {
                if (item.Active && item.CanSpawn()) {
                    Enemies.Add(item.SpawnOne(Map));
                }
            }

            // remove destroyed enemies and calc money and points
            List<Minion> remove = Enemies.Where(x => x.HitPoints < 1 || x.EndReached).ToList();
            foreach (var item in remove) {
                if (item.EndReached)
                    Life--;
                if (item.HitPoints < 1) {
                    Money = Money + item.Money;
                    Points = Points + item.Points;
                }

                Enemies.Remove(item);
                _destroyedEnemies++;
            }

            foreach (var enemy in Enemies)
            {
                enemy.Accept(AmountCalculatorVisitor);
            }

            foreach (var tower in _towers.Where(t => t.Dummy))
            {
                tower.Accept(AmountCalculatorVisitor);
                if (tower.GetType() == typeof(ArcherTower))
                {
                    ArcherTowersAmount = AmountCalculatorVisitor.TowersAmount;
                }
                else
                {
                    CannonTowersAmount = AmountCalculatorVisitor.TowersAmount;
                }
            }

            if (_destroyedEnemies >= 5 && !_decorated) {
                for (int i = 0; i < _towers.Count; i++) {
                    if (_towers[i].Active) {
                        _towers[i] = new KilledMinionsTowerDecorator(_towers[i]);
                    }
                }
                _decorated = true;
            }

            foreach (var item in Enemies) {
                item.Move(Map);
            }


            // add new bought towers
            foreach (var item in TowersToAdd) {
                item.EnableFire(true);
                _towers.Add(item);
            }
            TowersToAdd.Clear();

            // tower firing
            foreach (var item in _towers) {
                if (item.Dummy) {
                    item.CanBuy = item.CanBuyIt(Money);
                } else {
                    if (item.CanFire()) {
                        Bullet bb = item.Attack(Enemies);

                        if (bb != null) {
                            Bullets.Add(bb);
                        }
                    }
                }
            }

            // bullets removal and adding
            List<Bullet> removeB = Bullets.Where(x => x.Destroy).ToList();
            foreach (var item in removeB) {
                Bullets.Remove(item);
            }

            foreach (var item in Bullets) {
                item.Move(Enemies);
            }
        }

        public void SendNextLevel() {
            //Level level = null;
            if (Levels.Any(x => !x.Active)) {
                GameInfos.Add(new GameInfo {
                    Level = _currentLevel,
                    Life = Life,
                    Money = Money,
                    Points = Points
                });

                _currentLevel++;
                Points = Points + NextLevelCounterSeconds;
                Levels.First(x => !x.Active).Active = true;
                NextLevelCounterSeconds = _designatedNextLevelCounterSeconds;
            }
        }

        public void Draw(Graphics gfx, Pen pen) {
            foreach (var item in Enemies) {
                item.DrawSelf(gfx, pen);
            }

            foreach (var item in _towers) {
                item.DrawSelf(gfx, pen);
            }

            foreach (var item in Bullets) {
                item.DrawSelf(gfx, pen);
            }

            foreach (var item in Map.Roads) {
                item.DrawSelf(gfx, pen);
            }

            foreach (var item in Map.Junctions) {
                item.DrawSelf(gfx, pen);
            }

            SelectedTower?.DrawSelf(gfx, pen);
        }

        #region Memento

        public List<AbstractTower> GetClickedTowers(int x, int y, int height) {
            return _towers.Where(o =>
                o.Dummy && (float)x > o.Center.X - o.Width / 2 && x < o.Center.X + o.Width / 2 &&
                y > o.Center.Y - height / 2 && y < o.Center.Y + height / 2).ToList();
        }

        public void AddBoughtTower(AbstractTower tower) {
            this._towers.Add(tower);
        }

        public Memento.Memento SaveTowersState() {
            return new Memento.Memento(_towers.Select(o => (AbstractTower)o.Clone()).ToList());
        }

        public void RestoreTowersState(Memento.Memento restoreState) {
            restoreState.GetState(this);
        }

        public void SetTowersState(List<AbstractTower> newState) {
            _towers = newState;
        }

        #endregion
    }
}
