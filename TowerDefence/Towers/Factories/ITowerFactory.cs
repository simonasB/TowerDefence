using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers.Factories
{
    public interface ITowerFactory
    {
        AbstractTower CreateTower(BaseAttack baseAttackType);
    }
}
