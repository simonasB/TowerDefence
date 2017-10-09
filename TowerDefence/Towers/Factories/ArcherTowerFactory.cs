using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public class ArcherTowerFactory : ITowerFactory
    {
        public AbstractTower CreateTower(IAttack AttackType)
        {
            return new ArcherTower(AttackType);
        }
    }
}
