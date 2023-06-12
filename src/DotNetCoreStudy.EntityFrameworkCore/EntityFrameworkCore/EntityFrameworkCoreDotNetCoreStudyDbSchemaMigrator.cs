using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetCoreStudy.Data;
using Volo.Abp.DependencyInjection;

namespace DotNetCoreStudy.EntityFrameworkCore;

public class EntityFrameworkCoreDotNetCoreStudyDbSchemaMigrator
    : IDotNetCoreStudyDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDotNetCoreStudyDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DotNetCoreStudyDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DotNetCoreStudyDbContext>()
            .Database
            .MigrateAsync();
    }
}
