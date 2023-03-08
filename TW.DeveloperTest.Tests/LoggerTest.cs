using TW.DeveloperTest.Contracts;

namespace TW.DeveloperTest.Tests
{
    class CustomLogger : ILogger
    {
        private readonly Action<string, LogType> _messageAction;
        private readonly LogType _logLevel;

        public CustomLogger(Action<string, LogType> messageAction, LogType logLevel = LogType.Verbose)
        {
            this._messageAction = messageAction;
            this._logLevel = logLevel;
        }
        public void Log(string message, LogType logType)
        {
            if(logType >= _logLevel)
            {
                _messageAction(message, logType);
            }
        }
    }

    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestCustomLogger()
        {
            var testMsg = "";
            var testLogType = LogType.None;

            Action<string, LogType> testAction = (msg,  logType) => {
                testMsg = msg;
                testLogType = logType;
            };
 
            var customLogger = new CustomLogger(testAction);
            customLogger.Log("This is test debug message", LogType.Debug);

            Assert.AreEqual("This is test debug message", testMsg);
            Assert.AreEqual(LogType.Debug, testLogType);
        }

        [TestMethod]
        public void TestNotLoggedIfLogLevelIsLowerThanMessageLogType()
        {
            var testMsg = "";
            var testLogType = LogType.None;

            Action<string, LogType> testAction = (msg, logType) => {
                testMsg = msg;
                testLogType = logType;
            };

            var customLogger = new CustomLogger(testAction, LogType.Debug);
            customLogger.Log("This is test a verbose message", LogType.Verbose);

            Assert.AreEqual("", testMsg);
            Assert.AreEqual(LogType.None, testLogType);
        }
    }
}