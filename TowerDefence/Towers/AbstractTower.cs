using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers
{
    public abstract class AbstractTower
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        protected IAttack AttackType;

        public AbstractTower(IAttack AttackType)
        {
            this.AttackType = AttackType;
        }

        public void Attack()
        {
            AttackType.Attack();
        }
    }
}
