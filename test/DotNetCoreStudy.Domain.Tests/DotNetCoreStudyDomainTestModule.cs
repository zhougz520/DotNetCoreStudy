using DotNetCoreStudy.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DotNetCoreStudy;

[DependsOn(
    typeof(DotNetCoreStudyEntityFrameworkCoreTestModule)
    )]
public class DotNetCoreStudyDomainTestModule : AbpModule
{

}
