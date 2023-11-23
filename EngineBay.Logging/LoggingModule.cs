namespace EngineBay.Logging
{
    using EngineBay.Core;
    using Microsoft.AspNetCore.HttpLogging;

    public class LoggingModule : BaseModule
    {
        public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            var loggingLevel = LoggingConfiguration.GetLoggingLevel();
            var noisySystemsLoggingLevel = loggingLevel + 1; // We make noisy systems one level higher in log level so that we can run with Information level logging by default

            services.AddHttpLogging(o => o = new HttpLoggingOptions());
            services.AddLogging(builder =>
            {
                builder.AddFilter("EngineBay", loggingLevel);
                builder.AddFilter("Microsoft.AspNetCore", loggingLevel);
                builder.AddFilter("Microsoft", noisySystemsLoggingLevel);
                builder.AddFilter("Microsoft.AspNetCore.DataProtection", noisySystemsLoggingLevel);
                builder.AddFilter("System", noisySystemsLoggingLevel);
            });

            return services;
        }

        public override WebApplication AddMiddleware(WebApplication app)
        {
            app.UseHttpLogging();
            return app;
        }
    }
}