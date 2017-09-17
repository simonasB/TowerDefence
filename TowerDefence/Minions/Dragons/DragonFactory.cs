namespace TowerDefence.Minions.Dragons {
    public class DragonFactory : IMinionFactory {
        public IMinion CreateStrongMinion() {
            return new StrongDragon();
        }

        public IMinion CreateIntermediateMinion() {
            return new IntermediateDragon();
        }

        public IMinion CreateWeakMinion() {
            return new WeakDragon();
        }
    }
}
