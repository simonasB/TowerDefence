using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class MediumAttack : BaseAttack
    {
        public float Impact { get; } = 0.4f;

        protected override List<Minion> FindTargets(List<Minion> enemies, PointF center, int range) {
            throw new NotImplementedException();
        }

        protected override Minion SelectTarget(List<Minion> enemies) {
            throw new NotImplementedException();
        }

        protected override Bullet CreateBullet(PointF start, PointF target) {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            Console.WriteLine("Attacking enemy with medium impact: " + Impact);
        }
    }
}
