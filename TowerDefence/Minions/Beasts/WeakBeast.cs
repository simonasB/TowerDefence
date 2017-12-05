﻿using System.Drawing;
using TowerDefence.Core;
using TowerDefence.Flyweight;

namespace TowerDefence.Minions.Beasts {
    public class WeakBeast : Minion {
        public WeakBeast(float speed, int hitPoints, double moveDelayMilis, Map map) : base(speed, hitPoints, moveDelayMilis, map) {
            Health = 20;
            Name = nameof(WeakBeast);
            GameObjectType = GameObjectTypeFactory.GetGameObjectType("beast");
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            PointF a = new PointF(Center.X - (Width / 2), Center.Y - Height / 2);
            PointF a1 = Calc.RotatePoint(Center, a, Angle);

            GameObjectType.Draw(gfx, (int)(a1.X), (int)(a1.Y), Width, Height);

            if (Shooted)
            {
                gfx.FillEllipse(Brushes.Red, a1.X, a1.Y, Width, Height);
            }
            else
            {
                gfx.DrawEllipse(Pens.Blue, a1.X, a1.Y, Width, Height);
            }
            gfx.DrawString(HitPoints.ToString(), new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2),
                Center.Y - Height / 2 - 10);
        }
    }
}
