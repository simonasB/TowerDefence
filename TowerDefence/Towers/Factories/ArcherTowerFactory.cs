using TowerDefence.Core;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public class ArcherTowerFactory : ITowerFactory
    {
        public AbstractTower CreateTower(IAttack attackType)
        {
            return new ArcherTower(attackType) {
                Price = 10,
                Range = 100,
                TargetType = TargetType.All,
            };
        }
    }
}
