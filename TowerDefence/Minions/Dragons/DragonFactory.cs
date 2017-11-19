namespace TowerDefence.Minions.Dragons {
    public class DragonFactory : IMinionFactory {
        public Minion CreateStrongMinion() {
            return new StrongDragon(0, 0, 0, null);
        }

        public Minion CreateIntermediateMinion() {
            return new IntermediateDragon(0, 0, 0, null);
        }

        public Minion CreateWeakMinion() {
            return new WeakDragon(0, 0, 0, null);
        }
    }
}
