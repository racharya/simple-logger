using TW.DeveloperTest.Contracts;

namespace TW.DeveloperTest.Tests
{
    class CustomLogger : ILogger
    {
        private readonly Action<string, LogType> _messageAction;
        private readonly IMessageFormatter _messageFormatter;
        private readonly LogType _logLevel;

        public CustomLogger(Action<string, LogType> messageAction, IMessageFormatter? messageFormatter, LogType logLevel = LogType.Verbose)
        {
            this._messageAction = messageAction;
            this._messageFormatter = messageFormatter ?? new PassThroughMessageFormatter();
            this._logLevel = logLevel;
        }

        public CustomLogger(Action<string, LogType> messageAction, LogType logLevel = LogType.Verbose) : this(messageAction, null, logLevel)
        {
          
        }

        public void Log(string message, LogType logType)
        {
            if(logType >= _logLevel)
            {
                _messageAction(_messageFormatter.Format(message, logType), logType);
            }
        }
    }
}