﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TowerDefence.Core;
using TowerDefence.Towers;
using TowerDefence.Towers.Attack;
using TowerDefence.Towers.Factories;

namespace TowerDefence.UI
{
    public partial class Form1 : Form
    {
        private Game _game;
        private Thread _gameThread;
        private bool running = true;
        private Pen _myPen;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            _myPen = new Pen(Color.Black);

            InitGame();

            System.Windows.Forms.Timer Clock = new System.Windows.Forms.Timer();
            Clock.Interval = 10;
            Clock.Start();
            Clock.Tick += Timer_Tick;
        }

        public void InitGame() {
            _game = new Game(20) {Money = 10, Life = 50};

            GameLevel level = new GameLevel() {
                Count = 10,
                Money = 5,
                Speed = 0.6F,
                Points = 1,
                SpawnDelayMilis = 1000,
                Width = 10,
                Height = 10,
                HitPoints = 40,
                Ground = true,
                Active = true
            };

            _game.Levels.Add(level);
            level = new GameLevel() {
                Count = 10,
                Money = 10,
                Speed = 0.6F,
                Points = 1,
                SpawnDelayMilis = 1500,
                Width = 10,
                Height = 10,
                HitPoints = 40,
                Ground = true,
                Active = false
            };

            _game.Levels.Add(level);
            level = new GameLevel() {
                Count = 10,
                Money = 5,
                Speed = 0.5F,
                Points = 1,
                SpawnDelayMilis = 1000,
                Width = 10,
                Height = 10,
                HitPoints = 60,
                Ground = true,
                Active = false
            };
            _game.Levels.Add(level);

            Map map = new Map() {Start = new PointF(0, 10), End = new PointF(450, 170), RoadThickness = 20};
            _game.Map = map;
            map.AddRoad(100, Direction.Right);
            map.AddRoad(50, Direction.Down);
            map.AddRoad(50, Direction.Left);
            map.AddRoad(50, Direction.Down);
            map.AddRoad(150, Direction.Right);
            map.AddRoad(100, Direction.Up);
            map.AddRoad(90, Direction.Right);
            map.AddRoad(50, Direction.Down);
            map.AddRoad(130, Direction.Right);

            var archerTowerFactory = Utils.GetFactory<ITowerFactory>(nameof(ArcherTowerFactory));
            var cannonTowerFactory = Utils.GetFactory<ITowerFactory>(nameof(CannonTowerFactory));

            var archerTowerToBuy = archerTowerFactory.CreateTower(new EasyAttack());
            archerTowerToBuy.Center = new PointF(200, 300);
            archerTowerToBuy.Active = false;
            archerTowerToBuy.Dummy = true;

            _game.Towers.Add(archerTowerToBuy);

            var activeArcherTower = archerTowerFactory.CreateTower(new EasyAttack());
            activeArcherTower.Center = new PointF(150, 80);
            activeArcherTower.Active = true;
            activeArcherTower.Dummy = false;

            _game.Towers.Add(activeArcherTower);

            var cannonTowerToBuy = cannonTowerFactory.CreateTower(new EasyAttack());
            cannonTowerToBuy.Center = new PointF(250, 300);
            cannonTowerToBuy.Active = false;
            cannonTowerToBuy.Dummy = true;

            _game.Towers.Add(cannonTowerToBuy);

            var activeCannonTower = cannonTowerFactory.CreateTower(new EasyAttack());
            activeCannonTower.Center = new PointF(150, 120);
            activeCannonTower.Active = true;
            activeCannonTower.Dummy = false;

            _game.Towers.Add(activeCannonTower);

            _game.Running = true;
        }

        public void Timer_Tick(object sender, EventArgs eArgs) {
            if (running) {
                _game.Update(false);
                this.SuspendLayout();
                this.Refresh();
                this.ResumeLayout(false);
            }
        }

        public void Updating() {
            while (_game.Running) {
                _game.Update(false);

            }
            _gameThread.Join();
        }

        protected override void OnClosing(CancelEventArgs e) {
            running = false;
            base.OnClosing(e);
        }

        protected override void OnPaint(PaintEventArgs paintEvnt) {
            base.OnPaint(paintEvnt);
            Graphics gfx = paintEvnt.Graphics;
            _game.Draw(gfx, _myPen);
            lblLife.Text = _game.Life.ToString();
            lblMoney.Text = _game.Money.ToString();
            lblPoints.Text = _game.Points.ToString();
            lblNextWave.Text = _game.NextLevelCounterSeconds.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game.Running = !_game.Running;
            button1.Text = _game.Running ? "Pause" : "Play";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitGame();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            List<AbstractTower> towers = _game.Towers.Where(x =>
                x.Dummy && (float) e.X > x.Center.X - x.Width / 2 && e.X < x.Center.X + x.Width / 2 &&
                e.Y > x.Center.Y - Height / 2 && e.Y < x.Center.Y + Height / 2).ToList();
            if (towers.Count > 0 && towers.First().CanBuyIt(_game.Money)) {
                AbstractTower copy = Utils.ObjectCopier.Clone<AbstractTower>(towers.First());
                copy.EnableFire(false);
                _game.SelectedTower = copy;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            if (_game.SelectedTower != null) {
                if (!_game.SelectedTower.IsOverlapingRoads(_game.Map)) {
                    if (_game.Running)
                        _game.TowersToAdd.Add(_game.SelectedTower);
                    else // this is only enable tower placing and drwing on if paused
                    {
                        _game.Towers.Add(_game.SelectedTower);
                        _game.SelectedTower.EnableFire(true);
                        Refresh();
                    }

                    _game.Money = _game.Money - _game.SelectedTower.Price;
                    _game.SelectedTower = null;


                } else {
                    _game.SelectedTower = null;
                    if (!_game.Running)
                        Refresh();
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (_game.SelectedTower != null) {
                _game.SelectedTower.Center = new PointF(e.X, e.Y);
                _game.SelectedTower.InvalidPosisiton = _game.SelectedTower.IsOverlapingRoads(_game.Map);
                if (!_game.Running) {
                    _game.Draw(this.CreateGraphics(), _myPen);
                    this.Refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _game.SendNextLevel();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
