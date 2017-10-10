namespace TowerDefence.Towers.Decorators
{
    public class KilledMinions : TowerDecorator
    {
        public KilledMinions(AbstractTower tower) : base(tower) {
            Range = _tower.Range + 10;
        }
    }
}
