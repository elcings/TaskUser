using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Logger
{
    public class LogBootstrapper
    {
        public static void ConfigureLogger(IConfiguration configuration)
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();

            InternalLogger.LogToConsole = true;
            LogManager.ThrowConfigExceptions = true;
            LogManager.ThrowExceptions = false;

#if DEBUG
            LogManager.ThrowExceptions = true;
#endif

            fileTarget.FileName = configuration.GetSection("LogFileName").Value;

            fileTarget.Layout = "${counter} | ${date:format=yyyy-MM-dd HH\\:mm\\:ss.ffff} | ${machinename} | ${level:uppercase=true} | ${logger:shortName=true} | ${stacktrace} | ${message:exceptionSeparator=EXCEPTION:withException=true}";
            fileTarget.KeepFileOpen = true;

            var debugTarget = new DebuggerTarget();

#if DEBUG
            config.AddTarget("debug", debugTarget);
#endif
            config.AddTarget("file", fileTarget);

            var ruleFile = new LoggingRule("*", LogLevel.Trace, fileTarget);
            var ruleDebug = new LoggingRule("*", LogLevel.Trace, debugTarget);
#if DEBUG
            config.LoggingRules.Add(ruleDebug);
#endif
            config.LoggingRules.Add(ruleFile);


            LogManager.Configuration = config;
        }
    }
}
