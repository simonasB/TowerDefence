namespace TowerDefence.Minions {
    public interface IMinionFactory {
        Minion CreateStrongMinion();
        Minion CreateIntermediateMinion();
        Minion CreateWeakMinion();
    }
}
