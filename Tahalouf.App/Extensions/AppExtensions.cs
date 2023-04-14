using Microsoft.Extensions.DependencyInjection;
using Tahalouf.App.IService;
using Tahalouf.App.Services;

namespace Tahalouf.App.Extensions
{
    public static class AppExtensions
    {
        public static void AppConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<ISearchService, SearchService>();
        }
    }
}
