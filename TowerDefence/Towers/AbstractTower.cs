using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.Bullets;
using TowerDefence.Common;
using TowerDefence.Core;
using TowerDefence.Minions;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers
{
    [Serializable]
    public abstract class AbstractTower : GameObject
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set;}
        protected IAttack AttackType;

        #region StaticDefence

        public decimal Price { get; set; }
        public bool CanBuy { get; set; }
        public bool Active { get; set; }
        public bool Placed { get; set; }
        public bool Dummy { get; set; }
        public bool InvalidPosisiton { get; set; }
        public int FireDelayMilis { get; set; }
        protected DateTime LastFiredMilis { get; set; }
        public TargetType TargetType { get; set; }

        #endregion

        protected AbstractTower(IAttack attackType)
        {
            LastFiredMilis = DateTime.MinValue;
            Angle = Calc.DegreeToRadian(0);
            Placed = false;
            Active = false;
            Height = 10;
            Width = 10;
            FireDelayMilis = 1000;
            this.AttackType = attackType;
        }

        public virtual void Attack()
        {
            AttackType.Attack();
        }

        public abstract Bullet CreateBullet(PointF start, PointF target);

        public virtual Bullet Fire(Minion enemy)
        {
            if (enemy != null)
            {
                LastFiredMilis = DateTime.Now;
                Bullet bullet = CreateBullet(Center, enemy.Center);
                Angle = bullet.Angle;
                return bullet;
            }

            return null;
        }

        public Minion FindTarget(List<Minion> enemies) {
            if (!Active)
                return null;

            List<Minion> enemiesInRange = new List<Minion>();
            foreach (var item in enemies) {
                double dist = Calc.Distance(Center, item.Center);

                if (Range >= dist)
                    enemiesInRange.Add(item);
            }

            if (enemiesInRange.Count > 0)
                return enemiesInRange.First();

            return null;
        }

        public void EnableFire(bool enable) {
            Active = Placed = enable;
            Dummy = !enable;
        }
        public bool CanBuyIt(decimal money)
        {
            return money - Price >= 0;
        }

        public bool CanFire()
        {
            return Active && Placed && !Dummy && Calc.TimePassed(FireDelayMilis, LastFiredMilis);
        }

        public virtual List<Bullet> TryFire(List<Minion> enemies) {
            List<Bullet> bullets = new List<Bullet>();
            if (CanFire()) {
                Bullet bullet = TryFireOne(enemies);
                if (bullet != null)
                    bullets.Add(bullet);
            }

            return bullets;

        }

        public virtual Bullet TryFireOne(List<Minion> enemies) {
            Bullet bullet = null;
            if (CanFire()) {
                Minion enemy = FindTarget(enemies);
                if (enemy != null) {
                    bullet = Fire(enemy);
                }
            }
            return bullet;
        }

        public bool IsOverlapingRoads(Map map) {
            foreach (var item in map.Roads) {
                if (item.IsInside(new PointF(Center.X - Width, Center.Y)))
                    return true;
                if (item.IsInside(new PointF(Center.X + Width, Center.Y)))
                    return true;
                if (item.IsInside(new PointF(Center.X, Center.Y - Height)))
                    return true;
                if (item.IsInside(new PointF(Center.X, Center.Y + Height)))
                    return true;
            }

            foreach (var item in map.Junctions) {
                if (item.IsInside(new PointF(Center.X - Width, Center.Y)))
                    return true;
                if (item.IsInside(new PointF(Center.X + Width, Center.Y)))
                    return true;
                if (item.IsInside(new PointF(Center.X, Center.Y - Height)))
                    return true;
                if (item.IsInside(new PointF(Center.X, Center.Y + Height)))
                    return true;
            }

            return false;
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {


            if (!CanBuy && Dummy) {
                PointF a = new PointF(Center.X - (Width / 2), Center.Y - Height / 2);
                PointF b = new PointF(Center.X + Width / 2, Center.Y - Height / 2);
                PointF c = new PointF(Center.X + Width / 2, Center.Y + Height / 2);
                PointF d = new PointF(Center.X - Width / 2, Center.Y + Height / 2);

                gfx.FillPolygon(Brushes.Yellow, new PointF[5] {a, b, c, d, a});


            }

            if (InvalidPosisiton) {
                PointF a = new PointF(Center.X - (Width / 2), Center.Y - Height / 2);
                PointF b = new PointF(Center.X + Width / 2, Center.Y - Height / 2);
                PointF c = new PointF(Center.X + Width / 2, Center.Y + Height / 2);
                PointF d = new PointF(Center.X - Width / 2, Center.Y + Height / 2);

                gfx.FillPolygon(Brushes.Red, new PointF[5] {a, b, c, d, a});
            }

            if (Dummy) {
                gfx.DrawString(Price.ToString(), new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2),
                    Center.Y + Height / 2 + 7);
                //gfx.DrawString(Price.ToString(), new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2), Center.Y - Height / 2 - 7);

            }
        }
    }
}
