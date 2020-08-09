using AutoMapper;
using JetBrains.Annotations;
using Paper.Papers.MA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paper.Papers
{
    public class IndustryWheelService : IIndustryWheelService
    {
        private readonly IPaperMaService _maService;
        private readonly IMarketPaperService _paperService;
        private readonly IMapper _mapper;

        public IndustryWheelService(IPaperMaService maService,
            IMarketPaperService paperService,
            IMapper mapper)
        {
            _maService = maService;
            _paperService = paperService;
            _mapper = mapper;
        }

        public async Task<List<IndustryWheelDto>> GetAllIndustryWheel(IndustryWheelRequestDto input)
        {
            var papers = await _paperService.GetAllPaperAsync(_mapper.Map<PagedPaperRequestDto>(input));

            return papers.GroupBy(x => x.Industry).Select(x => new IndustryWheelDto()
            {
                Industry = x.Key,
                Weight = _mapper.Map<List<PointDto>>(GetIndustryWheel(x))
            }).ToList();
        }

        private Point[] GetIndustryWheel(IEnumerable<MarketPaper> papers)
        {
            int[] days = { };
            int i;
            Point[] r = null;
            foreach (var p in papers)
            {
                PaperMa[] ma = new PaperMa[days.Length];
                for (i = 0; i < days.Length; i++)
                    ma[i] = _maService.GetMa(p, days[i]);

                OrderedCalcPaperWheel paperWheel = new OrderedCalcPaperWheel(ma, p);

                if (r == null)
                    r = new Point[paperWheel.GetCount()];

                i = 0;
                foreach (var item in p.ExchangeInfo)
                    r[i++].Value += paperWheel.CalcuteWeight(item.Date, item.Price.Close);
            }

            return r;
        }
    }
}
