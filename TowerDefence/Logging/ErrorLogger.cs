using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class ErrorLogger : AbstractLogger
    {
        public ErrorLogger()
        {
            _level = LogLevel.ERROR;
        }

        protected override void Write(string message)
        {
            Logger.Instance().GetLogger().Error(message);
        }
    }
}
