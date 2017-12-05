using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class MediumAttack : IAttack
    {
        public float Impact { get; } = 0.4f;
        public Bullet Attack(List<Minion> enemies, PointF center, int range) {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with medium impact: " + Impact);
        }
    }
}
