namespace TW.DeveloperTest.Contracts
{
    public class MessageFormatterWithLogTypeInfo : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return $"[{logType.ToString().ToUpperInvariant()}] {message}";
        }
    }
}
