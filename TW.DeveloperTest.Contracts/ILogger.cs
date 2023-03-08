using System;

namespace TW.DeveloperTest.Contracts
{
    public enum LogType : ushort
    {
        None = 0,
        Verbose,
        Debug,
        Info, 
        Warning,
        Error,
        Critical
    }
    public interface ILogger
    {
        void Log(string message, LogType logType); 
    }

    public class ConsoleLogger : ILogger
    {
        private readonly LogType _logLevel;

        public ConsoleLogger(LogType logLevel)
        {
            this._logLevel = logLevel;
        }
        public void Log(string message, LogType logType = LogType.Verbose)
        {
            if(_logLevel >= logType)
            {
                Console.WriteLine(message);
            }
        }
    }

}
