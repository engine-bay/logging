namespace EngineBay.Logging
{
    using System;

    public abstract class LoggingConfiguration
    {
        public static bool IsSensativeDataLoggingEnabled()
        {
            var sensativeDataLoggingEnvironmentVariable = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.LOGGINGSENSATIVEDATAENABLED);

            if (string.IsNullOrEmpty(sensativeDataLoggingEnvironmentVariable))
            {
                return false;
            }

            if (sensativeDataLoggingEnvironmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Warning: {EnvironmentVariableConstants.LOGGINGSENSATIVEDATAENABLED} was set to 'true', PII data may appear in logs depending on the configured {EnvironmentVariableConstants.LOGGINGLEVEL} ");
                return true;
            }

            return false;
        }

        public static LogLevel GetLoggingLevel()
        {
            var loggingLevelEnvironmentVariable = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.LOGGINGLEVEL);

            if (string.IsNullOrEmpty(loggingLevelEnvironmentVariable))
            {
                return LogLevel.Warning;
            }

            var loggingLevel = (LogLevel)Enum.Parse(typeof(LogLevel), loggingLevelEnvironmentVariable);

            if (!Enum.IsDefined(typeof(LogLevel), loggingLevel) | loggingLevel.ToString().Contains(',', StringComparison.InvariantCulture))
            {
                Console.WriteLine($"Warning: '{loggingLevelEnvironmentVariable}' is not a valid {EnvironmentVariableConstants.LOGGINGLEVEL} configuration option. Valid options are: ");
                foreach (string name in Enum.GetNames(typeof(LogLevel)))
                {
                    Console.Write(name);
                    Console.Write(", ");
                }

                throw new ArgumentException($"Invalid {EnvironmentVariableConstants.LOGGINGLEVEL} configuration.");
            }

            return loggingLevel;
        }
    }
}