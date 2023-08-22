using log4net;
using log4net.Config;
using System.Reflection;

namespace LoggerUtility.LogUtility
{
    public static class Logger
    {
        private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        private static readonly ILog _log = GetLogger(typeof(Logger));

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }


        private static void EnsureLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


        }

        /// <summary>  
        /// Used to log Debug messages in an explicit Debug Logger  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Debug(string message)
        {
            EnsureLogger();

            _log.Debug(message);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Debug(string message, System.Exception exception)
        {
            EnsureLogger();
            _log.Debug(message, exception);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Info(string message)
        {
            EnsureLogger();
            _log.Info(message);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Info(string message, System.Exception exception)
        {
            EnsureLogger();
            _log.Info(message, exception);
        }

        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            EnsureLogger();
            _log.InfoFormat(format, arg0, arg1, arg2);

        }

        public static void InfoFormat(string format, object arg0, object arg1)
        {
            EnsureLogger();
            _log.InfoFormat(format, arg0, arg1);

        }

        public static void InfoFormat(string format, object arg0)
        {
            EnsureLogger();
            _log.InfoFormat(format, arg0);

        }

        public static void InfoFormat(string format, params object[] args)
        {
            EnsureLogger();
            _log.InfoFormat(format, args);

        }



        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Warn(string message)
        {
            EnsureLogger();
            _log.Warn(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Warn(string message, System.Exception exception)
        {
            EnsureLogger();
            _log.Warn(message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Error(string message)
        {
            EnsureLogger();
            _log.Error(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Error(string message, System.Exception exception)
        {
            EnsureLogger();
            _log.Error(message, exception);
        }
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Fatal(string message)
        {
            EnsureLogger();
            _log.Fatal(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Fatal(string message, System.Exception exception)
        {
            EnsureLogger();
            _log.Fatal(message, exception);
        }
    }
}
