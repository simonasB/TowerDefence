using System;
using System.Drawing;

namespace TowerDefence.Common {
    [Serializable]
    public abstract class GameObject {
        public PointF Center { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Angle { get; set; }

        public GameObjectType GameObjectType { get; set; }

        public abstract void DrawSelf(Graphics gfx, Pen pen);
    }
}
