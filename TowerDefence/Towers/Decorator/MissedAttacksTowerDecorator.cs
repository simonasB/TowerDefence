namespace TowerDefence.Towers.Decorator
{
    public class MissedAttacksTowerDecorator : TowerDecorator {
        private const int DecreasedDamage = 5;

        public MissedAttacksTowerDecorator(AbstractTower tower) : base(tower) {
            Damage = _tower.Damage - DecreasedDamage;
            EnhanceTower();
        }

        private void EnhanceTower() {
            Range = _tower.Range + DecreasedDamage;
            Logger.Instance()
                .Info(
                    $"Tower missed 15 attacks in a row. Decreasing their damage by {DecreasedDamage}");
            Logger.Instance().Info("Tower border color blue");
        }
    }
}
