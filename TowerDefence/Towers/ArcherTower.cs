using System;
using TowerDefence.Towers.Attack;

namespace TowerDefence.Towers {
    public class ArcherTower : AbstractTower { 
        public ArcherTower(IAttack AttackType) : base(AttackType)
        {
            Name = "Archer tower";
            Damage = 10;
            Range = 2;
        }

        public override void Attack() {
            Console.WriteLine($"{nameof(ArcherTower)} starts attack");
            AttackType.Attack();
        }
    }
}
