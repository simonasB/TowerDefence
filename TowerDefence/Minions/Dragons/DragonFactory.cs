namespace TowerDefence.Minions.Dragons {
    public class DragonFactory : IMinionFactory {
        public Minion CreateStrongMinion() {
            return new StrongDragon(0.4f, 40, 60) { Height = 15, Width = 15, Money = 12, Points = 2 };
        }

        public Minion CreateIntermediateMinion() {
            return new IntermediateDragon(0.4f, 35, 50) { Height = 13, Width = 13, Money = 10, Points = 1 };
        }

        public Minion CreateWeakMinion() {
            return new WeakDragon(0.3f, 30, 40) { Height = 11, Width = 11, Money = 8, Points = 1 };
        }
    }
}
