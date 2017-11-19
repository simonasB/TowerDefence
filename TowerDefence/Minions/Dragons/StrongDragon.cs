﻿using System.Drawing;
using TowerDefence.Core;

namespace TowerDefence.Minions.Dragons {
    public class StrongDragon : Minion {
        public StrongDragon(float speed, int hitPoints, double moveDelayMilis, Map map) : base(speed, hitPoints, moveDelayMilis, map) {
            Health = 50;
            Name = nameof(StrongDragon);
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            PointF a = new PointF(Center.X - (Width / 2), Center.Y - Height / 2);
            PointF a1 = Calc.RotatePoint(Center, a, Angle);

            if (Shooted) {
                gfx.FillEllipse(Brushes.Red, a1.X, a1.Y, Width, Height);
            } else {
                gfx.DrawEllipse(Pens.Red, a1.X, a1.Y, Width, Height);
            }
            gfx.DrawString(HitPoints.ToString(), new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2),
                Center.Y - Height / 2 - 10);
        }
    }
}
