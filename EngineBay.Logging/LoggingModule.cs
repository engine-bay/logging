namespace EngineBay.Logging
{
    using EngineBay.Core;

    public class LoggingModule : IModule
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            var loggingLevel = LoggingConfiguration.GetLoggingLevel();

            services.AddLogging(builder =>
            {
                builder.AddFilter("EngineBay", loggingLevel);
                builder.AddFilter("Microsoft", loggingLevel);
                builder.AddFilter("System", loggingLevel);
            });

            return services;
        }

        /// <inheritdoc/>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }

        public WebApplication AddMiddleware(WebApplication app)
        {
            app.UseHttpLogging();
            return app;
        }
    }
}