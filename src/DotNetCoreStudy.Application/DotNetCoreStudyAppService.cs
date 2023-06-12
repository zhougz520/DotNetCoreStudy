using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreStudy.Localization;
using Volo.Abp.Application.Services;

namespace DotNetCoreStudy;

/* Inherit your application services from this class.
 */
public abstract class DotNetCoreStudyAppService : ApplicationService
{
    protected DotNetCoreStudyAppService()
    {
        LocalizationResource = typeof(DotNetCoreStudyResource);
    }
}
