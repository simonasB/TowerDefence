namespace TowerDefence.Minions.Beasts {
    public class StrongBeast : IMinion {
        public int Health { get; } = 100;
        public string Name { get; } = nameof(StrongBeast);
    }
}
