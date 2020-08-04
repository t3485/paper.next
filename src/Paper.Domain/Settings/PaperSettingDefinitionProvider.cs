using Volo.Abp.Settings;

namespace Paper.Settings
{
    public class PaperSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(PaperSettings.MySetting1));
        }
    }
}
