namespace EngineBay.Logging.Tests
{
    using System;
    using EngineBay.Logging;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class LoggingConfigurationTests
    {
        [Fact]
        public void GetLoggingLevelEnvironmentVariableDebugShouldReturnDebug()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.LOGGINGLEVEL, "Debug");
            Assert.Equal(LogLevel.Debug, LoggingConfiguration.GetLoggingLevel());
        }

        [Fact]
        public void GetLoggingLevelEnvironmentVariableErrorShouldReturnError()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.LOGGINGLEVEL, "Error");
            Assert.Equal(LogLevel.Error, LoggingConfiguration.GetLoggingLevel());
        }

        [Fact]
        public void GetLoggingLevelEnvironmentVariableInvalidShouldThrowArgumentException()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.LOGGINGLEVEL, "Invalid");
            Assert.Throws<ArgumentException>(() => LoggingConfiguration.GetLoggingLevel());
        }
    }
}