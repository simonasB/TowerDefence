namespace TowerDefence.Towers.Decorators
{
    public class MissedAttacks : TowerDecorator
    {
        public MissedAttacks(AbstractTower tower) : base(tower) {
            Damage = _tower.Damage - 5;
        }
    }
}
