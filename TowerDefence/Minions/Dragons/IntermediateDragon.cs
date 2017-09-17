namespace TowerDefence.Minions.Dragons {
    public class IntermediateDragon : IMinion {
        public IntermediateDragon() {
            Health = 25;
            Name = nameof(IntermediateDragon);
        }
        public int Health { get; }
        public string Name { get; }
    }
}
