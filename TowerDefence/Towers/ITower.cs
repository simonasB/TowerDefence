namespace TowerDefence.Towers
{
    public interface ITower
    {
        string Name { get; }
        int Damage { get; }
        int Range { get; }

        void Attack();
    }
}
