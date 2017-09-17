namespace TowerDefence.Minions.Dragons {
    public class StrongDragon : IMinion {
        public StrongDragon() {
            Health = 50;
            Name = nameof(StrongDragon);
        }
        public int Health { get; }
        public string Name { get; }
    }
}
