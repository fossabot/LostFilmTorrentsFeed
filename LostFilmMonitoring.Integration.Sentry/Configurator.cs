using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Sentry;
using Sentry.AspNetCore;

namespace LostFilmMonitoring.Integration.Sentry
{
    public static class Configurator
    {
        public static void ConfigureSentry(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSentry(SentryAspNetCoreOptions);
        }

        public static IApplicationBuilder UseSentry(this IApplicationBuilder builder)
        {
            builder.UseSentryTracing();
            return builder;
        }

        private static readonly Action<SentryAspNetCoreOptions> SentryAspNetCoreOptions = sentryBuilder =>
        {
            sentryBuilder.BeforeSend = @event =>
            {
                // Never report server names
                return @event;
            };
            sentryBuilder.Dsn = Environment.GetEnvironmentVariable("SENTRY_DSN");
            sentryBuilder.Debug = true;
            sentryBuilder.TracesSampleRate = 0.01;
            sentryBuilder.AddEntityFramework();
        };
    }
}
