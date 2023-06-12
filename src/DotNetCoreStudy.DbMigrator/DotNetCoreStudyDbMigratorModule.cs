using DotNetCoreStudy.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DotNetCoreStudy.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DotNetCoreStudyEntityFrameworkCoreModule),
    typeof(DotNetCoreStudyApplicationContractsModule)
    )]
public class DotNetCoreStudyDbMigratorModule : AbpModule
{

}
