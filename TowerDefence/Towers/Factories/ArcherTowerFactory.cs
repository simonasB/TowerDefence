namespace TowerDefence.Towers.Factories
{
    public class ArcherTowerFactory : ITowerFactory
    {
        public ITower CreateTower()
        {
            return new ArcherTower();
        }
    }
}
