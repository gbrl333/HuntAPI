using Data;
using Repositories;

public static class DependencyInjectionConfig
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
    }
}