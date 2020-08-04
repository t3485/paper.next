using Paper.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Paper.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PaperPageModel : AbpPageModel
    {
        protected PaperPageModel()
        {
            LocalizationResourceType = typeof(PaperResource);
        }
    }
}