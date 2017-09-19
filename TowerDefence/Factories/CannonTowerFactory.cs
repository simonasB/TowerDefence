using TowerDefence.Towers;

namespace TowerDefence.Factories
{
    public class CannonTowerFactory : ITowerFactory
    {
        public ITower CreateTower()
        {
            return new CannonTower();
        }
    }
}
