﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TowerDefence.Common;
using TowerDefence.Core;
using TowerDefence.Memento;
using TowerDefence.Minions;
using TowerDefence.Towers;
using TowerDefence.Towers.Attack;
using TowerDefence.Towers.Factories;
using TowerDefence.Wave;
using TowerDefence.Wave.LevelProducers;

namespace TowerDefence.UI
{
    public partial class Form1 : Form
    {
        private Game _game;
        private bool running = true;
        private Pen _myPen;
        private readonly CareTaker _careTaker = new CareTaker();

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
                SpawnDelayMilis = 1000,
                Active = true,
                Level = 1,
                WaveContext = new WaveContext(new HardProducer(new ReflectionFactoryProvider<IMinionFactory>()))
            };

            _game.Levels.Add(level);
            level = new GameLevel() {
                Count = 10,
                SpawnDelayMilis = 1500,
                Active = false,
                Level = 2,
                WaveContext = new WaveContext(new HardProducer(new ReflectionFactoryProvider<IMinionFactory>()))
            };

            _game.Levels.Add(level);
            level = new GameLevel() {
                Count = 10,
                SpawnDelayMilis = 1000,
                Active = false,
                Level = 3,
                WaveContext = new WaveContext(new HardProducer(new ReflectionFactoryProvider<IMinionFactory>()))
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

            var towers = new List<AbstractTower>();

            var archerTowerToBuy = archerTowerFactory.CreateTower(new HardAttack());
            archerTowerToBuy.Center = new PointF(200, 300);
            archerTowerToBuy.Active = false;
            archerTowerToBuy.Dummy = true;

            //var image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pics/tower_archer.png"));

            var activeArcherTower = archerTowerFactory.CreateTower(new HardAttack());
            activeArcherTower.Center = new PointF(150, 80);
            activeArcherTower.Active = true;
            activeArcherTower.Dummy = false;
            activeArcherTower.Placed = true;
            //activeArcherTower.Image = new Bitmap(image, new Size(activeArcherTower.Width, activeArcherTower.Height));

            var cannonTowerToBuy = cannonTowerFactory.CreateTower(new HardAttack());
            cannonTowerToBuy.Center = new PointF(250, 300);
            cannonTowerToBuy.Active = false;
            cannonTowerToBuy.Dummy = true;

            var activeCannonTower = cannonTowerFactory.CreateTower(new HardAttack());
            activeCannonTower.Center = new PointF(150, 120);
            activeCannonTower.Active = true;
            activeCannonTower.Dummy = false;
            activeCannonTower.Placed = true;
            //activeCannonTower.Image = new Bitmap(image, new Size(activeCannonTower.Width, activeCannonTower.Height)); ;

            //_game.Running = true;

            

            towers.Add(activeArcherTower);
            towers.Add(archerTowerToBuy);
            towers.Add(cannonTowerToBuy);
            towers.Add(activeCannonTower);
            _game.SetTowersState(towers);

            var memento = _game.SaveTowersState();

            _careTaker.Add(memento);
        }

        public void Timer_Tick(object sender, EventArgs eArgs) {
            if (running) {
                _game.Update(false);
                this.SuspendLayout();
                this.Refresh();
                this.ResumeLayout(false);
            }
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
            lblEnemiesAmount.Text = _game.AmountCalculatorVisitor.TotalMoney.ToString();
            lblArcherTowersAmount.Text = _game.ArcherTowersAmount.ToString();
            lblCanonTowersAmount.Text = _game.CannonTowersAmount.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitGame();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            List<AbstractTower> towers = _game.GetClickedTowers(e.X, e.Y, Height);
            if (towers.Count > 0 && towers.First().CanBuyIt(_game.Money)) {
                //AbstractTower copy = Utils.ObjectCopier.Clone<AbstractTower>(towers.First());
                AbstractTower copy = (AbstractTower)towers.First().Clone();
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
                        _game.AddBoughtTower(_game.SelectedTower);                   
                        _game.SelectedTower.EnableFire(true);
                        Refresh();
                    }

                    _careTaker.Add(_game.SaveTowersState());

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

        private void start_Click(object sender, EventArgs e) {
            labelState.Text = _game.GameState.OnStart();
        }

        private void pause_Click(object sender, EventArgs e) {
            labelState.Text = _game.GameState.OnPause();
        }

        private void surrender_Click(object sender, EventArgs e) {
            labelState.Text = _game.GameState.OnSurrender();
            InitGame();
        }

        private void undoTower_Click(object sender, EventArgs e) {
            if (_careTaker.Size() > 0) {
                var memento = _careTaker.Get(_careTaker.Size() - 1);
                _game.Money += 2;
                _game.RestoreTowersState(memento);
            }
        }
    }
}
