namespace TowerDefence.Towers.Decorator {
    public abstract class TowerDecorator : AbstractTower {
        protected readonly AbstractTower _tower;

        protected TowerDecorator(AbstractTower tower) : base(null){
            _tower = tower;
            Name = tower.Name;
            Damage = tower.Damage;
            Range = tower.Range;
        }
        
        public override void Attack() {
            _tower.Attack();
        }
    }
}
