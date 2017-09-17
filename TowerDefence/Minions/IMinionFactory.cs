namespace TowerDefence.Minions {
    public interface IMinionFactory {
        IMinion CreateStrongMinion();
        IMinion CreateIntermediateMinion();
        IMinion CreateWeakMinion();
    }
}
