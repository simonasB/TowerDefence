namespace TowerDefence.Minions.Demons {
    public class DemonFactory : IMinionFactory {
        public Minion CreateStrongMinion() {
            return new StrongDemon();
        }

        public Minion CreateIntermediateMinion() {
            return new IntermediateDemon();
        }

        public Minion CreateWeakMinion() {
            return new WeakDemon();
        }
    }
}
