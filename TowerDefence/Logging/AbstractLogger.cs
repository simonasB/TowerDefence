using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public enum LogLevel
    {
        INFO = 1,
        DEBUG = 2,
        ERROR = 3,
        FATAL = 4
    };

    abstract class AbstractLogger
    {
        protected AbstractLogger _nextLogger;
        protected LogLevel _level;

        public AbstractLogger SetNextLogger(AbstractLogger nextLogger)
        {
            return _nextLogger = nextLogger;
        }

        public void LogMessage(LogLevel level, String message)
        {
            if (_level <= level)
            {
                Write(message);
            }
            else if (_nextLogger != null)
            {
                _nextLogger.LogMessage(level, message);
            }
        }

        abstract protected void Write(String message);
    }
}
