using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paper.Data
{
    /* This is used if database provider does't define
     * IPaperDbSchemaMigrator implementation.
     */
    public class NullPaperDbSchemaMigrator : IPaperDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}