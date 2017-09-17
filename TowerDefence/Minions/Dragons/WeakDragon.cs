namespace TowerDefence.Minions.Dragons {
    public class WeakDragon : IMinion {
        public WeakDragon() {
            Health = 10;
            Name = nameof(WeakDragon);
        }
        public int Health { get; }
        public string Name { get; }
    }
}
