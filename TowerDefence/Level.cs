using System;

namespace TowerDefence
{
    class Level : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
