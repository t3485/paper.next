using Paper.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Paper.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class PaperController : AbpController
    {
        protected PaperController()
        {
            LocalizationResource = typeof(PaperResource);
        }
    }
}