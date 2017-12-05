using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Minions;

namespace TowerDefence.Bullets {
    public class HeavyBullet : Bullet {
        public const int DamageDefault = 10;

        public int SlowPercent { get; set; }
        public int SlowDuration { get; set; }

        public HeavyBullet(PointF start, PointF target)
            : base(start, target) {
            Height = 50;
            Width = 50;
            Damage = DamageDefault;
            Speed = 20;
            MoveDelayMilis = 0;
        }

        public override void HitTargets(List<Minion> enemies) {
            foreach (var item in enemies) {
                item.Damage(Damage);
            }
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            if (Center == Target) {
                gfx.FillEllipse(Brushes.Gainsboro, Center.X - (Width / 2), Center.Y - Height / 2, Width, Height);
            } else {
                gfx.FillEllipse(Brushes.Black, Center.X - 2, Center.Y - 2, 4, 4);
            }
        }
    }
}
