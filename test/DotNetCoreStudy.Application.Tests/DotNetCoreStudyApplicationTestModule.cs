using Volo.Abp.Modularity;

namespace DotNetCoreStudy;

[DependsOn(
    typeof(DotNetCoreStudyApplicationModule),
    typeof(DotNetCoreStudyDomainTestModule)
    )]
public class DotNetCoreStudyApplicationTestModule : AbpModule
{

}
