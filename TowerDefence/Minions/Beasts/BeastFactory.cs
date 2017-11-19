namespace TowerDefence.Minions.Beasts {
    public class BeastFactory : IMinionFactory {
        public Minion CreateStrongMinion() {
            return new StrongBeast(0, 0, 0, null);
        }

        public Minion CreateIntermediateMinion() {
            return new IntermediateBeast(0, 0, 0, null);
        }

        public Minion CreateWeakMinion() {
            return new WeakBeast(0, 0, 0, null);
        }
    }
}
