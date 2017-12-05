using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class InfoLogger : AbstractLogger
    {
        public InfoLogger()
        {
            _level = LogLevel.INFO;
        }

        protected override void Write(string message)
        {
            Logger.Instance().GetLogger().Info(message);
        }
    }
}
