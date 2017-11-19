using System.Drawing;
using TowerDefence.Bullets;

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

        public override void DrawSelf(Graphics gfx, Pen pen) {
            base._tower.DrawSelf(gfx, pen);
        }

        public override Bullet CreateBullet(PointF start, PointF target) {
            return base._tower.CreateBullet(start, target);
        }
    }
}
