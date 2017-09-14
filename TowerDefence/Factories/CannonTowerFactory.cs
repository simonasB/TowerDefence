using TowerDefence.Towers;

namespace TowerDefence.Factories
{
    class CannonTowerFactory : ITowerFactory
    {
        public ITower CreateTower()
        {
            return new CannonTower();
        }
    }
}
