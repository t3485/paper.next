using Paper.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Paper.Papers
{
    public class MarketPaperService : PaperAppService, IMarketPaperService
    {
        //private IRepository<MarketPaper, int> _paperRepository;
        private IPaperRepository _paperRepository;
        private readonly IObjectMapper _mapper;

        public MarketPaperService(IPaperRepository paperRepository, IObjectMapper mapper)
        {
            _paperRepository = paperRepository;
            _mapper = mapper;
        }

        public Task<List<MarketPaper>> GetAllPaperAsync(PagedPaperRequestDto input)
        {
            return _paperRepository.GetAllIncludePriceAsync(input.Begin, input.End, input.Type);
        }
    }
}
