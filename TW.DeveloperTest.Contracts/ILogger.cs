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

    public interface IMessageFormatter
    {
        string Format(string message, LogType logType);
    }

    public class MessageFormatterWithTimeStamp : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return $"{DateTime.Now.ToString()} {message}";
        }
    }

    public class MessageFormatterWithLogTypeInfo : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return $"[{logType.ToString().ToUpperInvariant()}] {message}";
        }
    }

    public class PassThroughMessageFormatter : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return message;
        }
    }


    public class ConsoleLogger : ILogger
    {
        private readonly LogType _logLevel;
        private readonly IMessageFormatter _messageFormatter;

        public ConsoleLogger(IMessageFormatter messageFormatter = null, LogType logLevel = LogType.None)
        {
            _logLevel = logLevel;
            _messageFormatter = messageFormatter ?? new PassThroughMessageFormatter();
        }

        public ConsoleLogger()
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
