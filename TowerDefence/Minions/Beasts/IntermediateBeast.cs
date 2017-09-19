namespace TowerDefence.Minions.Beasts {
    public class IntermediateBeast : IMinion {
        public int Health { get; } = 25;
        public string Name { get; } = nameof(IntermediateBeast);
    }
}
