namespace EngineBay.Logging
{
    using EngineBay.Core;

    public class LoggingModule : IModule
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(builder =>
            {
                builder.AddFilter("EngineBay", LogLevel.Information);
                builder.AddFilter("Microsoft", LogLevel.Warning);
                builder.AddFilter("System", LogLevel.Error);
                builder.AddFilter("Microsoft.AspNetCore.Authentication", LogLevel.Debug);

                // consider making logging providers configurable
                // https://learn.microsoft.com/en-us/dotnet/core/extensions/console-log-formatter
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