using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces;
using TeamHost.Infrastructure.Services;

namespace TeamHost.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSignalR();

        services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IStoreService, StoreService>();
    }
}