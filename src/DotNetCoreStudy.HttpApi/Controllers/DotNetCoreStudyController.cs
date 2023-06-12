using DotNetCoreStudy.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DotNetCoreStudy.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DotNetCoreStudyController : AbpControllerBase
{
    protected DotNetCoreStudyController()
    {
        LocalizationResource = typeof(DotNetCoreStudyResource);
    }
}
