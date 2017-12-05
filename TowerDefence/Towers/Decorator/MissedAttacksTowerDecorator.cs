using System.Drawing;
using TowerDefence.Bullets;

namespace TowerDefence.Towers.Decorator
{
    public class MissedAttacksTowerDecorator : TowerDecorator {
        private const int DecreasedDamage = 5;

        public MissedAttacksTowerDecorator(AbstractTower tower) : base(tower) {
            Damage = _tower.Damage - DecreasedDamage;
            WeakenTower();
        }

        private void WeakenTower() {
            Range = _tower.Range + DecreasedDamage;
            Logger.Instance().Log(LogLevel.INFO,
                    $"Tower missed 15 attacks in a row. Decreasing their damage by {DecreasedDamage}");
            Logger.Instance().Log(LogLevel.INFO, "Tower border color blue");
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            throw new System.NotImplementedException();
        }
    }
}
