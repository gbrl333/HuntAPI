using HuntAPI.Repositories;
using HuntAPI.Repositories.Interfaces;
using HuntAPI.Services;
using HuntAPI.Services.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace HuntAPI.Config
{
    public static class DependencyInjectionConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IHuntRepository, HuntRepository>();
            services.AddScoped<IHuntService, HuntService>();
        }
    }
}