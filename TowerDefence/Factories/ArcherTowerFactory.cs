using TowerDefence.Towers;

namespace TowerDefence.Factories
{
    class ArcherTowerFactory : ITowerFactory
    {
        public ITower CreateTower()
        {
            return new ArcherTower();
        }
    }
}
