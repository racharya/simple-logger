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

    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestLoggingWithPassthrougFormatter()
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

        [TestMethod]
        public void TestLoggingWithMessageFormatting()
        {
            var testMsg = "";
            var testLogType = LogType.None;

            Action<string, LogType> testAction = (msg, logType) => {
                testMsg = msg;
                testLogType = logType;
            };

            var customLogger = new CustomLogger(testAction, new MessageFormatterWithLogTypeInfo());
            customLogger.Log("This is test debug message", LogType.Debug);

            Assert.AreEqual("[DEBUG] This is test debug message", testMsg);
            Assert.AreEqual(LogType.Debug, testLogType);
        }
    }
}