using System.Collections.Generic;
using System.Drawing;
using TowerDefence.Bullets;
using TowerDefence.Minions;

namespace TowerDefence.Towers.Attack
{
    public interface IAttack
    {
        float Impact { get; }

        Bullet Attack(List<Minion> enemies, PointF center, int range);
    }
}
