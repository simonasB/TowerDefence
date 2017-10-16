namespace TowerDefence.Towers.Decorator
{
    public class KilledMinionsTowerDecorator : TowerDecorator {
        private const int IncreasedRange = 10;

        public KilledMinionsTowerDecorator(AbstractTower tower) : base(tower) {
            EnhanceTower();
        }

        private void EnhanceTower() {
            Range = _tower.Range + IncreasedRange;
            Logger.Instance()
                .Info(
                    $"Towers killed 10 minions in a row. Enhancing their range by {IncreasedRange}");
            Logger.Instance().Info("Tower border color red");
        }
    }
}
