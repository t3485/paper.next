using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paper.Papers
{
    public class MarketPaperService : PaperAppService, IMarketPaperService
    {
        private IRepository<MarketPaper, int> _paperRepository;

        public MarketPaperService(IRepository<MarketPaper, int> paperRepository)
        {
            _paperRepository = paperRepository;
        }

        public async Task<int> GetListAsync(PagedPaperRequestDto input)
        {
            var list = await _paperRepository.GetListAsync(true);

            var price = list[0].WeekExchangeInfo;

            return 1;
        }
    }
}
