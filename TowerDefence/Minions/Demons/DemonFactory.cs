namespace TowerDefence.Minions.Demons {
    public class DemonFactory : IMinionFactory {
        public IMinion CreateStrongMinion() {
            return new StrongDemon();
        }

        public IMinion CreateIntermediateMinion() {
            return new IntermediateDemon();
        }

        public IMinion CreateWeakMinion() {
            return new WeakDemon();
        }
    }
}
