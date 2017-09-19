using System;

namespace TowerDefence.Towers {
    public class ArcherTower : ITower {
        public string Name { get; } = "Archer tower";

        public int Damage { get; } = 10;

        public int Range { get; } = 2;

        public void Attack() {
            Console.WriteLine($"{nameof(ArcherTower)} starts attack");
        }
    }
}
