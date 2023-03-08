using System;

namespace TW.DeveloperTest.Contracts
{
    public class MessageFormatterWithTimeStamp : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return $"{DateTime.Now.ToString()} {message}";
        }
    }
}
