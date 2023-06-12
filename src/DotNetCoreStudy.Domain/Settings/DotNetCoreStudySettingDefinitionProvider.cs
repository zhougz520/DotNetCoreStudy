using Volo.Abp.Settings;

namespace DotNetCoreStudy.Settings;

public class DotNetCoreStudySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DotNetCoreStudySettings.MySetting1));
    }
}
