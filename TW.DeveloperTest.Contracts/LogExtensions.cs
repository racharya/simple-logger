namespace TW.DeveloperTest.Contracts
{
    public static class LogExtensions
    {
        public static void LogVerbose(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Verbose);
        }

        public static void LogDebug(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Debug);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Info);
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Warning);
        }

        public static void LogError(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Error);
        }

        public static void LogCritical(this ILogger logger, string message)
        {
            logger.Log(message, LogType.Critical);
        }
    }
}
