using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Paper.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(PaperHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PaperConsoleApiClientModule : AbpModule
    {
        
    }
}
