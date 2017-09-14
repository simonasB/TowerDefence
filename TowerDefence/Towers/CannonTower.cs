namespace TowerDefence.Towers
{
    class CannonTower : ITower
    {
        string name = "Cannon tower";
        int damage = 20;
        int range = 1;

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
