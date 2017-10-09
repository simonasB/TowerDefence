namespace TowerDefence.Towers.Decorators {
    public class TowerDecorator : ITower {
        protected readonly ITower _tower;
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }

        public TowerDecorator(ITower tower) {
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
