using System.Drawing;

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
            base._tower.DrawSelf(gfx, pen);

            gfx.DrawString("D", new Font("Arial", 5), Brushes.Black, Center.X - (Width / 2),
                Center.Y + Height / 2 + 7);
        }
    }
}
