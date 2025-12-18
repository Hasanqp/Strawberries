using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace Common.Lgging
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> cfg =>
            (context, LoggerConfiguration) =>
            {
                var env = context.HostingEnvironment;
                LoggerConfiguration.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspHosting.Lifetime", Serilog.Events.LogEventLevel.Warning)
                .WriteTo.Console();

                if(context.HostingEnvironment.IsDevelopment())
                {
                    LoggerConfiguration.MinimumLevel.Override("Catalog", Serilog.Events.LogEventLevel.Debug);
                    LoggerConfiguration.MinimumLevel.Override("Basket", Serilog.Events.LogEventLevel.Debug);
                    LoggerConfiguration.MinimumLevel.Override("Discount", Serilog.Events.LogEventLevel.Debug);
                    LoggerConfiguration.MinimumLevel.Override("Ordering", Serilog.Events.LogEventLevel.Debug);
                }
            };
    }
}
