using System.Drawing;

namespace TowerDefence.Towers.Decorator
{
    public class KilledMinionsTowerDecorator : TowerDecorator {
        private const int IncreasedRange = 10;

        public KilledMinionsTowerDecorator(AbstractTower tower) : base(tower) {
            EnhanceTower();
        }

        private void EnhanceTower() {
            Range = _tower.Range + IncreasedRange;
            Logger.Instance().Log(LogLevel.INFO,
                    $"Towers killed 10 minions in a row. Enhancing their range by {IncreasedRange}");
            Logger.Instance().Log(LogLevel.INFO, "Tower border color red");
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            base._tower.DrawSelf(gfx, pen);

            gfx.DrawString("D", new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2),
                Center.Y + Height / 2 + 7);
        }
    }
}
