namespace TowerDefence.Towers.Decorators {
    public class SuccessfulAttacks : TowerDecorator {
        public SuccessfulAttacks(ITower tower) : base(tower) {
            Damage += _tower.Damage + 20;
        }
    }
}
