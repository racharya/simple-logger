namespace TW.DeveloperTest.Contracts
{
    public enum LogType
    {
        Debug,
        Info, 
        Warning,
    }
    public interface ILogger
    {
        void Log(string message, LogType logType); 
    }

}
