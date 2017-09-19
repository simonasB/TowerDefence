namespace TowerDefence.Minions.Demons
{
    public class IntermediateDemon : IMinion {
        public int Health { get; } = 10;
        public string Name { get; } = nameof(IntermediateDemon);
    }
}
