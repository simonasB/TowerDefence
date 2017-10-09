using System;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers {
    public class CannonTower : AbstractTower {

        public CannonTower(IAttack AttackType) : base(AttackType)
        {
            Name = "Cannon tower";
            Damage = 20;
            Range = 1;
        }

        public new void Attack() {
            Console.WriteLine($"{nameof(CannonTower)} starts attack");
            AttackType.Attack();
        }
    }
}
