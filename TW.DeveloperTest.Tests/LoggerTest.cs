using TW.DeveloperTest.Contracts;

namespace TW.DeveloperTest.Tests
{
    class CustomLogger : ILogger
    {
        private readonly Action<string, LogType> _messageFunc;

        public CustomLogger(Action<string, LogType> messageFunc)
        {
            this._messageFunc = messageFunc;
        }
        public void Log(string message, LogType logType)
        {
            _messageFunc(message, logType);
        }
    }
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestCustomLogger()
        {
            var testMsg = "";
            var testLogType = LogType.Info;

            Action<string, LogType> testAction = (msg,  logType) => {
                testMsg = msg;
                testLogType = logType;
            };
 
            var customLogger = new CustomLogger(testAction);
            customLogger.Log("This is test debug message", LogType.Debug);

            Assert.AreEqual("This is test debug message", testMsg);
            Assert.AreEqual(LogType.Debug, testLogType);
        }
    }
}