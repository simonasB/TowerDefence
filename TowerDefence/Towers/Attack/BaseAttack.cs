using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    public abstract class BaseAttack
    {
        float Impact { get; }

        public Bullet Attack(List<Minion> enemies, PointF center, int range) {
            Bullet bullet = null;

            var targets = FindTargets(enemies, center, range);
            var enemy = SelectTarget(targets);
            if (enemy != null)
            {
                bullet = CreateBullet(center, enemy.Center);
            }

            return bullet;
        }

        protected abstract List<Minion> FindTargets(List<Minion> enemies, PointF center, int range);

        protected abstract Minion SelectTarget(List<Minion> enemies);

        protected abstract Bullet CreateBullet(PointF start, PointF target);
    }
}
