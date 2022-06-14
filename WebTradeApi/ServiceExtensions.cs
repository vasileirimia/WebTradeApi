using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebTradeApi.Persistece;
using WebTradeApi.Persistece.Repository;
using WebTradeApi.Services;

namespace WebTradeApi
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            // UseInMemoryDatabase for this assignment          
            services.AddDbContext<TradeContext>(opt => opt.UseInMemoryDatabase("Trade"), ServiceLifetime.Singleton);
            services.AddAutoMapper(Assembly.GetAssembly(typeof(TradeMappingProfile)));

            services.AddTransient<IAggregateRepository, AggregateRepository>();
            services.AddTransient<ITradeRepository, TradeRepository>();
            services.AddTransient<IPortofolioRepository, PortofolioRepository>();
            services.AddTransient<IMarketRepository, MarketRepository>();

            services.AddTransient<ITradeService, TradeService>(); //AddScoped AddSingleton AddTransient
            services.AddTransient<IPortofolioService, PortofolioService>();
            services.AddTransient<IMarketService, MarketService>();
        }
    }
}
