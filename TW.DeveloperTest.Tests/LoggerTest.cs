using TW.DeveloperTest.Contracts;

namespace TW.DeveloperTest.Tests
{

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

        [TestMethod]
        public void TestLoggingWithExtensionMethods()
        {
            var testMsg = "";
            var testLogType = LogType.None;

            Action<string, LogType> testAction = (msg, logType) => {
                testMsg = msg;
                testLogType = logType;
            };

            var customLogger = new CustomLogger(testAction, new MessageFormatterWithLogTypeInfo());
            customLogger.LogDebug("This is test debug message");

            Assert.AreEqual("[DEBUG] This is test debug message", testMsg);
            Assert.AreEqual(LogType.Debug, testLogType);
        }
    }
}