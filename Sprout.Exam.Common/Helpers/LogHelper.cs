using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sprout.Exam.Common.Helpers
{
    public static class LogHelper
    {
        private static readonly ILog _applicationLog = LogManager.GetLogger("Application");
        private static readonly ILog _exceptionLog = LogManager.GetLogger("Exception");

        public static void InitializeConfiguration(string configFolder)
        {
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            GlobalContext.Properties["host"] = ((string[])AppDomain.CurrentDomain.FriendlyName.Split(':')).FirstOrDefault();
            XmlConfigurator.ConfigureAndWatch(logRepository, new FileInfo(Path.Combine(configFolder, "Log4Net.config")));
        }


        public static void LogInfo(string message)
        {
            _applicationLog.Info(message);
        }

        public static void LogException(Exception ex)
        {
            _exceptionLog.Error("Exception:", ex);
        }
    }
}
