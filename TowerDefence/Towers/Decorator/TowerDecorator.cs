namespace TowerDefence.Towers.Decorator {
    public abstract class TowerDecorator : AbstractTower {
        protected readonly AbstractTower _tower;

        protected TowerDecorator(AbstractTower tower) : base(tower.AttackType)
        {
            _tower = tower;

            Name = _tower.Name;
            Damage = _tower.Damage;
            Range = _tower.Range;
            Price = _tower.Price;
            CanBuy = _tower.CanBuy;
            Active = _tower.Active;
            Placed = _tower.Placed;
            Dummy = _tower.Dummy;
            InvalidPosisiton = _tower.InvalidPosisiton;
            FireDelayMilis = _tower.FireDelayMilis;
            Center = _tower.Center;
            Width = _tower.Width;
            Height = _tower.Height;
            Angle = _tower.Angle;
        }
    }
}
