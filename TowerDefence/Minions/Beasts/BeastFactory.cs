namespace TowerDefence.Minions.Beasts {
    public class BeastFactory : IMinionFactory {
        public IMinion CreateStrongMinion() {
            return new StrongBeast();
        }

        public IMinion CreateIntermediateMinion() {
            return new IntermediateBeast();
        }

        public IMinion CreateWeakMinion() {
            return new WeakBeast();
        }
    }
}
