namespace TowerDefence.Minions.Demons {
    public class WeakDemon : IMinion {
        public int Health { get; } = 10;
        public string Name { get; } = nameof(WeakDemon);
    }
}
