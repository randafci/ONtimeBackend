using System;
using Microsoft.Extensions.DependencyInjection;
using OnTime.Shared.Common.Caching;
using OnTime.Shared.Common.Messaging;
using OnTime.Shared.Common.BackgroundJobs;
using OnTime.Shared.Common.Monitoring;
using Hangfire;

namespace OnTime.Shared.Common.Configuration
{
    public static class CrossCuttingConfiguration
    {
        public static IServiceCollection AddCrossCuttingConcerns(
            this IServiceCollection services,
            string redisConnectionString,
            string rabbitMqConnectionString,
            string hangfireConnectionString,
            string applicationInsightsKey)
        {
            // Cache Service
            services.AddSingleton<ICacheService>(provider => 
                new RedisCacheService(redisConnectionString));

            // Message Bus
            services.AddSingleton<IMessageBus>(provider => 
                new RabbitMQMessageBus(rabbitMqConnectionString));

            // Background Jobs
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangfireConnectionString));

            services.AddHangfireServer();
            services.AddSingleton<IBackgroundJobService, HangfireJobService>();

            // Monitoring
            //var monitoringService = new ApplicationInsightsService(applicationInsightsKey);
            //services.AddSingleton<IMetricsService>(monitoringService);
            //services.AddSingleton<ITelemetryService>(monitoringService);

            return services;
        }
    }
} 