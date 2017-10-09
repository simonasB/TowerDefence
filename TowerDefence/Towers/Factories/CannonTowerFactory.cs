using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public class CannonTowerFactory : ITowerFactory
    {
        public AbstractTower CreateTower(IAttack AttackType)
        {
            return new CannonTower(AttackType);
        }
    }
}
