using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.Bullets;
using TowerDefence.Core;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class HardAttack : IAttack {
        public float Impact { get; } = 0.8f;

        public Bullet Attack(List<Minion> enemies, PointF center, int range) {
            return TryFire(enemies, center, range);
        }

        private Bullet TryFire(List<Minion> enemies, PointF center, int range) {
            Bullet bullet = null;

            Minion enemy = FindTarget(enemies, center, range);
            if (enemy != null) {
                bullet = Fire(enemy, center);
            }

            return bullet;
        }

        private Bullet Fire(Minion enemy, PointF center) {
            if (enemy != null) {
                Bullet bullet = CreateBullet(center, enemy.Center);
                return bullet;
            }

            return null;
        }

        private Minion FindTarget(List<Minion> enemies, PointF center, int range) {
            List<Minion> enemiesInRange = new List<Minion>();
            foreach (var item in enemies) {
                double dist = Calc.Distance(center, item.Center);

                if (range >= dist)
                    enemiesInRange.Add(item);
            }

            if (enemiesInRange.Count > 0)
                return enemiesInRange.First();

            return null;
        }

        private Bullet CreateBullet(PointF start, PointF target) {
            return new HeavyBullet(start, target) {TargetType = TargetType.Ground};
        }
    }
}
