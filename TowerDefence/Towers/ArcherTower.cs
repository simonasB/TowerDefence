using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Core;
using TowerDefence.Flyweight;
using TowerDefence.Minions;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers {
    [Serializable]
    public class ArcherTower : AbstractTower { 
        public ArcherTower(BaseAttack attackType) : base(attackType)
        {
            Name = "Archer tower";
            Damage = 10;
            Range = 2;
            GameObjectType = GameObjectTypeFactory.GetGameObjectType("archerTower");
        }

        public override Bullet Attack(List<Minion> enemies) {
            Console.WriteLine($"{nameof(ArcherTower)} starts attack");
            return CanFire() ? base.Attack(enemies) : null;
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            base.DrawSelf(gfx, pen);

            GameObjectType.Draw(gfx, (int)(Center.X - (Width / 2)), (int)(Center.Y), Width, Height);

            if (!Dummy)
            {
                Pen penn = new Pen(Color.Gray, 1);
                gfx.DrawEllipse(penn, Center.X - Range, Center.Y - Range, Range * 2, Range * 2);
            }
            if (Dummy)
            {
                gfx.DrawString((1000 / FireDelayMilis * SimpleBullet.DamageDefault).ToString(), new Font("Arial", 7), Brushes.Black, Center.X - (Width / 2), Center.Y - 15);
            }
        }
    }
}
