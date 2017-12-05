using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.Bullets;
using TowerDefence.Core;
using TowerDefence.Flyweight;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    [Serializable]
    public class HardAttack : BaseAttack {
        public float Impact { get; } = 0.8f;

        protected override List<Minion> FindTargets(List<Minion> enemies, PointF center, int range) {
            List<Minion> enemiesInRange = new List<Minion>();
            foreach (var item in enemies) {
                double dist = Calc.Distance(center, item.Center);

                if (range >= dist)
                    enemiesInRange.Add(item);
            }

            return enemiesInRange;
        }

        protected override Minion SelectTarget(List<Minion> enemies) {
            return enemies.FirstOrDefault();
        }

        protected override Bullet CreateBullet(PointF start, PointF target) {
            return new HeavyBullet(start, target) {
                TargetType = TargetType.Ground,
                GameObjectType = GameObjectTypeFactory.GetGameObjectType("heavyBullet")
            };
        }
    }
}
