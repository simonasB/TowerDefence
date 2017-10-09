using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public interface ITowerFactory
    {
        AbstractTower CreateTower(IAttack AttackType);
    }
}
