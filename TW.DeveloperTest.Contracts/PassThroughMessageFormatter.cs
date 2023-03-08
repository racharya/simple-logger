namespace TW.DeveloperTest.Contracts
{
    public class PassThroughMessageFormatter : IMessageFormatter
    {
        public string Format(string message, LogType logType)
        {
            return message;
        }
    }
}
