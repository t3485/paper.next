using System.Threading.Tasks;

namespace Paper.Data
{
    public interface IPaperDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
