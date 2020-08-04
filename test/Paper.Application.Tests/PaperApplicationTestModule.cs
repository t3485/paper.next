using Volo.Abp.Modularity;

namespace Paper
{
    [DependsOn(
        typeof(PaperApplicationModule),
        typeof(PaperDomainTestModule)
        )]
    public class PaperApplicationTestModule : AbpModule
    {

    }
}