using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Paper.EntityFrameworkCore
{
    [DependsOn(
        typeof(PaperEntityFrameworkCoreModule)
        )]
    public class PaperEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PaperMigrationsDbContext>();
        }
    }
}
