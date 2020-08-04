using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Paper.Localization;
using Paper.Papers;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Paper
{
    /* Inherit your application services from this class.
     */
    public abstract class PaperAppService : ApplicationService
    {
        protected PaperAppService()
        {
            LocalizationResource = typeof(PaperResource);
        }
    }
}
