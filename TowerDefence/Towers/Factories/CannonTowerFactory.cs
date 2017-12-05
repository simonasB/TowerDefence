using TowerDefence.Core;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public class CannonTowerFactory : ITowerFactory
    {
        public AbstractTower CreateTower(BaseAttack baseAttackType)
        {
            return new CannonTower(baseAttackType) {
                Price = 50,
                Range = 120,
                TargetType = TargetType.All,
            };
        }
    }
}
