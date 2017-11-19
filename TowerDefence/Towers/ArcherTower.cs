﻿using System;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Core;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers {
    [Serializable]
    public class ArcherTower : AbstractTower { 
        public ArcherTower(IAttack attackType) : base(attackType)
        {
            Name = "Archer tower";
            Damage = 10;
            Range = 2;
        }

        public override void Attack() {
            Console.WriteLine($"{nameof(ArcherTower)} starts attack");
            AttackType.Attack();
        }

        public override Bullet CreateBullet(PointF start, PointF target) {
            return new HeavyBullet(start, target) { TargetType = TargetType.Ground };
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            base.DrawSelf(gfx, pen);

            PointF a = new PointF(Center.X + Width / 2, Center.Y);
            PointF b = new PointF(Center.X - Width / 2, Center.Y + Height / 2);
            PointF c = new PointF(Center.X - Width / 2, Center.Y - Height / 2);

            PointF a1 = Calc.RotatePoint(Center, a, Angle);
            PointF b1 = Calc.RotatePoint(Center, b, Angle);
            PointF c1 = Calc.RotatePoint(Center, c, Angle);

            Brush brush = Brushes.Gray;
            gfx.FillPolygon(brush, new PointF[4] { a1, b1, c1, a1 });
            gfx.DrawPolygon(pen, new PointF[4] { a1, b1, c1, a1 });

            if (!Dummy)
            {

                Pen penn = new Pen(Color.Gray, 1);
                gfx.DrawEllipse(penn, Center.X - Range, Center.Y - Range, Range * 2, Range * 2);
            }
            if (Dummy)
            {
                gfx.DrawString((1000 / FireDelayMilis * TeslaBullet.DamageDefault).ToString(), new Font("Arial", 7), Brushes.Black, Center.X - (Width / 2), Center.Y - 15);
            }
        }
    }
}
