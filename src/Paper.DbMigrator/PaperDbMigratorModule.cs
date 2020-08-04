using Paper.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Paper.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PaperEntityFrameworkCoreDbMigrationsModule),
        typeof(PaperApplicationContractsModule)
        )]
    public class PaperDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
