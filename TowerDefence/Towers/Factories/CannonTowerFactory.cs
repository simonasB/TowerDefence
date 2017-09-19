namespace TowerDefence.Towers.Factories
{
    public class CannonTowerFactory : ITowerFactory
    {
        public ITower CreateTower()
        {
            return new CannonTower();
        }
    }
}
