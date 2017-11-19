﻿using System.Drawing;

namespace TowerDefence.Bullets
{
    public class TeslaBullet : Bullet {
        public const int DamageDefault = 2;

        public TeslaBullet(PointF start, PointF target)
            : base(start, target) {
            Height = 2;
            Width = 2;
            Damage = DamageDefault;
            //Speed = 10000;
            MoveDelayMilis = 0;
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            //PointF a = new PointF(Center.X + Width / 2, Center.Y);
            //PointF b = new PointF(Center.X + Width / 2, Center.Y + Width / 2);
            //PointF c = new PointF(Center.X - Width / 2, Center.Y - Width / 2);

            gfx.DrawLine(new Pen(Brushes.Orange, 2), Start.X, Start.Y, Target.X, Target.Y);
            //gfx.DrawPolygon(pen, new PointF[3] { Calc.RotatePoint(Center, a, Angle), Calc.RotatePoint(Center, b, Angle), Calc.RotatePoint(Center, c, Angle) });
        }
    }
}
