using Paper.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paper
{
    [DependsOn(
        typeof(PaperEntityFrameworkCoreTestModule)
        )]
    public class PaperDomainTestModule : AbpModule
    {

    }
}