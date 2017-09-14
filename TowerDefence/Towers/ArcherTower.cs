namespace TowerDefence.Towers
{
    public class ArcherTower : ITower
    {
        string name = "Archer tower";
        int damage = 10;
        int range = 2;

        public int getDamage()
        {
            return damage;
        }

        public int getRange()
        {
            return range;
        }

        public string getName()
        {
            return name;
        }
    }
}
