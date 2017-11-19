using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Core;
using TowerDefence.Minions;

namespace TowerDefence.Bullets {
    public class SonicBullet : Bullet {
        public const int DamageDefault = 2;

        protected List<Minion> HitedTargets;
        List<PointF> pointsPassed;
        public float Range { get; set; }

        public SonicBullet(PointF start, PointF target)
            : base(start, target) {
            Width = 20;
            Height = 20;
            Speed = 20;
            Damage = DamageDefault;
            MoveDelayMilis = 10;

            pointsPassed = new List<PointF>();
            HitedTargets = new List<Minion>();
        }

        public override void Move(List<Minion> enemies) {
            if (Destroy)
                return;

            if ((DateTime.Now - _lastMoveTime).TotalMilliseconds < MoveDelayMilis)
                return;

            _lastMoveTime = DateTime.Now;

            _passedDistance = _passedDistance + Speed;
            if (_passedDistance > Range) {
                Destroy = true;
            } else {
                Center = Calc.GetPoint(Center, Angle, Speed);
                List<Minion> found = FindEnemiesAtPosition(enemies);
                foreach (var item in HitedTargets) {
                    found.Remove(item);
                }
                HitTargets(found);
                HitedTargets.AddRange(found);
                pointsPassed.Add(Center);

            }
        }

        public override void HitTargets(List<Minion> enemies) {
            foreach (var item in enemies) {
                item.Damage(Damage);
            }
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            int x = pointsPassed.Count;
            foreach (var item in pointsPassed) {
                PointF a = new PointF(item.X + Width / 2, item.Y - Width / 2 / x);
                PointF b = new PointF(item.X + Width / 2, item.Y + Width / 2 / x);
                x--;
                gfx.DrawLines(pen, new PointF[2] {Calc.RotatePoint(item, a, Angle), Calc.RotatePoint(item, b, Angle)});
            }
        }
    }
}
