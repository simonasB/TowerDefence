using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Common;
using TowerDefence.Core;
using TowerDefence.Minions;
using TowerDefence.Towers.Attack;
using TowerDefence.Visitor;

namespace TowerDefence.Towers
{
    [Serializable]
    public abstract class AbstractTower : GameObject, ICloneable, IAcceptVisitorComponent
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set;}
        public BaseAttack AttackType { get; set; }

        #region StaticDefence

        public decimal Price { get; set; }
        public bool CanBuy { get; set; }
        // If shooting
        public bool Active { get; set; }
        public bool Placed { get; set; }
        // For buying
        public bool Dummy { get; set; }
        public bool InvalidPosisiton { get; set; }
        public int FireDelayMilis { get; set; }
        protected DateTime LastFiredMilis { get; set; }
        public TargetType TargetType { get; set; }

        #endregion

        protected AbstractTower(BaseAttack attackType)
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

        public virtual Bullet Attack(List<Minion> enemies) {
            var bullet = AttackType.Attack(enemies, Center, Range);
            LastFiredMilis = DateTime.Now;

            if (bullet != null) {
                Angle = bullet.Angle;
            }

            return bullet;
        }

        public virtual void EnableFire(bool enable) {
            Active = Placed = enable;
            Dummy = !enable;
        }
        public virtual bool CanBuyIt(decimal money)
        {
            return money - Price >= 0;
        }

        public bool CanFire()
        {
            return Active && Placed && !Dummy && Calc.TimePassed(FireDelayMilis, LastFiredMilis);
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

        public object Clone() {
            return MemberwiseClone();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
