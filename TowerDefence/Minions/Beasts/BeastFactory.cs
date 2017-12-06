namespace TowerDefence.Minions.Beasts {
    public class BeastFactory : IMinionFactory {
        public Minion CreateStrongMinion() {
            return new StrongBeast(0.6f, 60, 80) { Height = 12, Width = 12, Money = 15, Points = 3 };
        }

        public Minion CreateIntermediateMinion() {
            return new IntermediateBeast(0.6f, 40, 90) { Height = 11, Width = 11, Money = 10, Points = 2 };
        }

        public Minion CreateWeakMinion() {
            return new WeakBeast(0.5f, 40, 100) { Height = 10, Width = 10, Money = 5, Points = 1 };
        }
    }
}
