using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompaniesHouse
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        internal static ServiceProvider ConfigureServices()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //setup DI
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddLazyCache()
            .AddSingleton<IConfiguration>(configuration)
            .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
