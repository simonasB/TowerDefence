namespace TowerDefence.Towers.Decorators {
    public class SuccessfulAttacks : TowerDecorator {
        public SuccessfulAttacks(AbstractTower tower) : base(tower) {
            Damage += _tower.Damage + 20;
        }
    }
}
