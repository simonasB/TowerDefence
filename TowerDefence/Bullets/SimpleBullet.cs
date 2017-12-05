using System.Drawing;

namespace TowerDefence.Bullets {
    public class SimpleBullet : Bullet {
        public const int DamageDefault = 1;

        public SimpleBullet(PointF start, PointF target) : base(start, target) {
            Height = 2;
            Width = 2;
            Damage = DamageDefault;
            Speed = 20;
            MoveDelayMilis = 0;
        }

        public override void DrawSelf(Graphics gfx, Pen pen) {
            //gfx.FillEllipse(Brushes.Black, Center.X - 1F, Center.Y - 1F, 2, 2);
            GameObjectType.Draw(gfx, (int) (Center.X - 1F), (int) (Center.Y - 1F), Width, Height);
        }
    }
}
