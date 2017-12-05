using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class DebugLogger : AbstractLogger
    {
        public DebugLogger()
        {
            _level = LogLevel.DEBUG;
        }

        protected override void Write(string message)
        {
            Logger.Instance().GetLogger().Debug(message);
        }
    }
}
