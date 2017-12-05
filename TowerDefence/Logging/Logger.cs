using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace TowerDefence {
    public class Logger {

        private static volatile Logger _instance;
        private static readonly object _syncRoot = new object();
        private static ILog _logger;
        private AbstractLogger _chainedLogger;

        private Logger() {
            if (_logger == null) {

                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
                var configFile = new FileInfo("App.config");

                XmlConfigurator.Configure(logRepository, configFile);

                _logger = LogManager.GetLogger(nameof(TowerDefence));

                _chainedLogger = new FatalLogger();
                _chainedLogger
                    .SetNextLogger(new ErrorLogger())
                    .SetNextLogger(new DebugLogger())
                    .SetNextLogger(new InfoLogger());
            }

        }

        public static Logger Instance() {

            if (_instance == null) {
                lock (_syncRoot) {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }

            return _instance;
        }

        public ILog GetLogger()
        {
            return _logger;
        }

        public void Log(LogLevel level, string message)
        {
            _chainedLogger.LogMessage(level, message);
        }
    }
}
