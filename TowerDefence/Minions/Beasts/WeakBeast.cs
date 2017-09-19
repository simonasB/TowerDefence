namespace TowerDefence.Minions.Beasts {
    public class WeakBeast : IMinion {
        public int Health { get; } = 20;
        public string Name { get; } = nameof(WeakBeast);
    }
}
