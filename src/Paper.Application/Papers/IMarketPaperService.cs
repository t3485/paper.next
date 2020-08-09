using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Paper.Papers
{
    public interface IMarketPaperService : IApplicationService, IRemoteService, ITransientDependency
    {
        Task<List<MarketPaper>> GetAllPaperAsync(PagedPaperRequestDto input);
    }
}
