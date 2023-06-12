using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DotNetCoreStudy.Data;

/* This is used if database provider does't define
 * IDotNetCoreStudyDbSchemaMigrator implementation.
 */
public class NullDotNetCoreStudyDbSchemaMigrator : IDotNetCoreStudyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
