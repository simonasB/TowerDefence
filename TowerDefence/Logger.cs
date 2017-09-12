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

        private Logger() {
            if (_logger == null) {

                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
                var configFile = new FileInfo("App.config");

                XmlConfigurator.Configure(logRepository, configFile);

                _logger = LogManager.GetLogger(nameof(TowerDefence));
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


        public void Fatal(Object message) {
            _logger.Fatal(message);
        }

        public void Fatal(Object message, Exception exception) {
            _logger.Fatal(message, exception);
        }

        public void Error(Object message) {
            _logger.Error(message);
        }

        public void Error(Object message, Exception exception) {
            _logger.Error(message, exception);

        }

        public void Debug(Object message) {
            _logger.Debug(message);
        }

        public void Info(Object message) {
            _logger.Info(message);
        }
    }
}
