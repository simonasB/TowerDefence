using System.Drawing;

namespace TowerDefence.Core {
    public struct Vector {
        public PointF Point { get; set; }
        public double Angle { get; set; }
        public float Distance { get; set; }
        public PointF Middle { get; set; }
    }
}
