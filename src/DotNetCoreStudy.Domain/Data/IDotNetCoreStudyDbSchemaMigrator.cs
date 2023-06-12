using System.Threading.Tasks;

namespace DotNetCoreStudy.Data;

public interface IDotNetCoreStudyDbSchemaMigrator
{
    Task MigrateAsync();
}
