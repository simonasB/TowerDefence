namespace TowerDefence.Towers.Decorators {
    public class TowerDecorator : AbstractTower {
        protected readonly AbstractTower _tower;
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }

        public TowerDecorator(AbstractTower tower) : base(null){
            _tower = tower;
            Name = tower.Name;
            Damage = tower.Damage;
            Range = tower.Range;
        }
        
        public virtual void Attack() {
            _tower.Attack();
        }
    }
}
