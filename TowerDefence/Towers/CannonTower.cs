using System;

namespace TowerDefence.Towers {
    public class CannonTower : ITower {
        public string Name { get; } = "Cannon tower";

        public int Damage { get; } = 20;

        public int Range { get; } = 1;

        public void Attack() {
            Console.WriteLine($"{nameof(CannonTower)} starts attack");
        }
    }
}
