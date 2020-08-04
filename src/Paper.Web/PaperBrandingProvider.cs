using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Paper.Web
{
    [Dependency(ReplaceServices = true)]
    public class PaperBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Paper";
    }
}
