using System;

namespace TW.DeveloperTest.Contracts
{
    public class ConsoleLogger : ILogger
    {
        private readonly LogType _logLevel;
        private readonly IMessageFormatter _messageFormatter;

        public ConsoleLogger(IMessageFormatter messageFormatter = null, LogType logLevel = LogType.None)
        {
            _logLevel = logLevel;
            _messageFormatter = messageFormatter ?? new PassThroughMessageFormatter();
        }

        public ConsoleLogger(LogType logLevel) : this(null, logLevel)
        {

        }


        public void Log(string message, LogType logType = LogType.Verbose)
        {
            if(_logLevel >= logType)
            {
                Console.WriteLine(_messageFormatter.Format(message, logType));
            }
        }
    }
}
