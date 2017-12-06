﻿using System;
using System.Drawing;
using System.Linq;
using TowerDefence.Common;
using TowerDefence.Core;
using TowerDefence.Mediator;

namespace TowerDefence.Minions {
    public abstract class Minion : GameObject {
        private readonly IMinionDamageControl _minionDamageControl;
        public int Health { get; set; }
        public string Name { get; set; }

        public Map Map { get; set; }

        public int Points { get; set; }
        public decimal Money { get; set; }
        public bool EndReached { get; set; }

        public PointF Start { get; set; }
        public PointF End { get; set; }

        public bool Destroy { get; set; }
        public int HitPoints { get; set; }
        public float Speed { get; set; }
        protected float _designatedSpeed { get; set; }

        public bool Shooted { get; set; }
        public double MoveDelayMilis { get; set; }
        protected DateTime _lastMoveTime { get; set; }
        public int MoveCount { get; set; }

        public int SlowPercent { get; set; }
        public int SlowDuration { get; set; }
        protected bool _slowed;

        public int LastReceivedDamage { get; set; }

        protected Minion(float speed, int hitPoints, double moveDelayMilis, IMinionDamageControl minionDamageControl)
        {
            _minionDamageControl = minionDamageControl;
            Speed = speed;
            HitPoints = hitPoints;
            MoveDelayMilis = moveDelayMilis;
            MoveDelayMilis = 0;
            _lastMoveTime = DateTime.Now;
            //MoveDelayMilis = 20;

            Shooted = false;
            MoveCount = 0;

            SlowDuration = 0;
            SlowPercent = 0;
            _slowed = false;

            _designatedSpeed = Speed;
            Destroy = false;

            EndReached = false;
            minionDamageControl.RegisterMinionUnderGuidance(this);
        }

        public void PositionEnemyForStart(Map map) {
            this.Map = map;

            Road first = map.Roads.First();
            if (first.Direction == Direction.Right)
                Center = new PointF(map.Start.X + 0.1F, map.Start.Y + map.RoadThickness / 2);
            else if (first.Direction == Direction.Left)
                Center = new PointF(map.Start.X + 0.1F, map.Start.Y + map.RoadThickness / 2);
            else if (first.Direction == Direction.Down)
                Center = new PointF(map.Start.X + map.RoadThickness / 2, Start.Y + 0.1F);
            else if (first.Direction == Direction.Up)
                Center = new PointF(map.Start.X + map.RoadThickness / 2, Start.Y + 0.1F);
        }

        public override int GetHashCode()
        {
            return Center.X.GetHashCode() + Center.Y.GetHashCode() + Angle.GetHashCode();
        }

        public virtual bool Move(Map map)
        {

            if (HitPoints < 1)
                return false;

            if (EndReached)
                return false;

            if ((DateTime.Now - _lastMoveTime).TotalMilliseconds < MoveDelayMilis)
                return false;

            _lastMoveTime = DateTime.Now;

            Shooted = false;

            MoveCount++;

            if (!_slowed && SlowPercent > 0)
            {
                Speed = Speed - Speed * SlowPercent / 100;
                _slowed = true;
            }
            SlowDuration = SlowDuration > 0 ? SlowDuration - 1 : 0;
            SlowPercent = SlowDuration > 0 ? SlowPercent : 0;
            if (SlowPercent == 0)
            {
                _slowed = false;
                Speed = _designatedSpeed;
            }

            EndReached = map.EndReached(Center);

            // Can be moved to be unique for each enemy (ground, air or dragon/beast)
            if (MoveCount > 5)
            {
                Vector vector = map.MoveOnRoad(Center, Speed, Angle, 15);
                Angle = vector.Angle;
                Center = vector.Point;
                MoveCount = 0;
            }

            Vector vector1 = map.MoveOnRoad(Center, Speed, Angle, 0);
            Angle = vector1.Angle;
            Center = vector1.Point;

            return true;
        }

        public virtual void SetSlow(int slowPercent, int slowDuration)
        {
            if (slowPercent > SlowPercent)
            {
                SlowPercent = slowPercent;
                SlowDuration += slowDuration;
                //_slowed = true;
            }
        }

        public virtual void Damage(int damage)
        {
            Shooted = true;
            HitPoints = HitPoints - damage;
            LastReceivedDamage = damage;
            _minionDamageControl.ReceiveMinionLocation(this);
        }

    }
}
