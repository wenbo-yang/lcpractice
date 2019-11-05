using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC359_LogRateLimiter
{
    [TestClass]
    public class LogRateLimiterTests
    {
        [TestMethod]
        public void GivenLoggerAndNewMessage_ShouldLogMessage_ShouldReturnTrue()
        {
            var logger = new Logger();

            var result = logger.ShouldLogMessage("test", 0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenLoggerSetOfMessages_ShouldLogMessage_ShouldReturnCorrectly()
        {
            var logger = new Logger();

            var result = logger.ShouldLogMessage("test", 0);
            Assert.IsTrue(result);

            result = logger.ShouldLogMessage("test1", 1);
            Assert.IsTrue(result);

            result = logger.ShouldLogMessage("test", 9);
            Assert.IsFalse(result);

            result = logger.ShouldLogMessage("test", 10);
            Assert.IsTrue(result);
        }
    }

    public class Logger
    {
        private const int LIMIT = 10;
        private Dictionary<string, int> _logHistory = new Dictionary<string, int>();

        public bool ShouldLogMessage(string log, int time)
        {
            if (!_logHistory.ContainsKey(log))
            {
                _logHistory.Add(log, time);
                return true;
            }
            else if (time - _logHistory[log] >= 10)
            {
                _logHistory[log] = time;
                return true;
            }

            return false;
        }
    }
}
