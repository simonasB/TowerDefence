namespace TowerDefence.Towers.Decorators
{
    public class KilledMinions : TowerDecorator
    {
        public KilledMinions(ITower tower) : base(tower) {
            Range = _tower.Range + 10;
        }
    }
}
