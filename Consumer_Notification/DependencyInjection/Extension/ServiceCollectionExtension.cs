using Consumer_Notification.DependencyInjection.Options;
using MassTransit;
using System.Reflection;

namespace Consumer_Notification.DependencyInjection.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigureMediatR(this IServiceCollection services) =>
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        public static IServiceCollection AddConfigureMassTransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);
            services.AddMassTransit(mt =>
            {
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, account =>
                    {
                        account.Username(masstransitConfiguration.Username);
                        account.Password(masstransitConfiguration.Password);
                    });
                    bus.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
