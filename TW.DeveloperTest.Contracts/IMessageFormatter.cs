namespace TW.DeveloperTest.Contracts
{
    public interface IMessageFormatter
    {
        string Format(string message, LogType logType);
    }
}
