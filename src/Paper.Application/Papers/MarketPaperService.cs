using Paper.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paper.Papers
{
    public class MarketPaperService : PaperAppService, IMarketPaperService
    {
        //private IRepository<MarketPaper, int> _paperRepository;
        private IPaperRepository _paperRepository;

        public MarketPaperService(IPaperRepository paperRepository)
        {
            _paperRepository = paperRepository;
        }

        public Task<List<MarketPaper>> GetAllPaperAsync(PagedPaperRequestDto input)
        {
            return _paperRepository.GetListAsync();
        }
    }
}
