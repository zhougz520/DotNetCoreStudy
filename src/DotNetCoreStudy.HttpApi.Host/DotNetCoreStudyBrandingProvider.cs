using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DotNetCoreStudy;

[Dependency(ReplaceServices = true)]
public class DotNetCoreStudyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DotNetCoreStudy";
}
