using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.Bullets;
using TowerDefence.Database.Entities;
using TowerDefence.Minions;
using TowerDefence.Towers;
using TowerDefence.Towers.Decorator;

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
        public List<AbstractTower> Towers { get; set; }
        public List<AbstractTower> TowersToAdd { get; set; }
        public List<GameLevel> Levels { get; set; }

        public AbstractTower SelectedTower { get; set; }

        public List<GameInfo> GameInfos { get; set; }

        private int _currentLevel = 1;
        private int _destroyedEnemies = 0;
        private bool _decorated;
        protected bool Updating { get; set; }

        public Game(int nextWaveCounterSec) {
            _designatedNextLevelCounterSeconds = nextWaveCounterSec;
            NextLevelCounterSeconds = nextWaveCounterSec;

            Clock.Interval = 1000;
            Clock.Start();
            Clock.Tick += Timer_Tick;

            Map = new Map();

            Enemies = new List<Minion>();
            Bullets = new List<Bullet>();
            Towers = new List<AbstractTower>();
            TowersToAdd = new List<AbstractTower>();
            Levels = new List<GameLevel>();
            GameInfos = new List<GameInfo>();
        }

        public void Timer_Tick(object sender, EventArgs eArgs) {
            if (Running) {
                NextLevelCounterSeconds--;
            }
        }

        public void Update(bool force) {
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

            if (_destroyedEnemies >= 5 && !_decorated) {
                for (int i = 0; i < Towers.Count; i++) {
                    if (Towers[i].Active) {
                        Towers[i] = new KilledMinionsTowerDecorator(Towers[i]);
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
                Towers.Add(item);
            }
            TowersToAdd.Clear();

            // tower firing
            foreach (var item in Towers) {
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

            foreach (var item in Towers) {
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
    }
}
