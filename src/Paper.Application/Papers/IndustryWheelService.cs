using JetBrains.Annotations;
using Paper.Papers.MA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Paper.Papers
{
    public class IndustryWheelService : PaperAppService, IIndustryWheelService
    {
        private readonly IPaperMaService _maService;
        private readonly IMarketPaperService _paperService;

        public IndustryWheelService(IPaperMaService maService,
            IMarketPaperService paperService)
        {
            _maService = maService;
            _paperService = paperService;
        }

        public async Task<List<IndustryWheelDto>> GetAllIndustryWheel(IndustryWheelRequestDto input)
        {
            var papers = await _paperService.GetAllPaperAsync(
                ObjectMapper.Map<IndustryWheelRequestDto, PagedPaperRequestDto>(input));

            return papers.GroupBy(x => x.Industry).Select(x => new IndustryWheelDto()
            {
                Industry = x.Key,
                Weight = ObjectMapper.Map<Point[], List<PointDto>>(GetIndustryWheel(x))
            }).ToList();
        }

        private Point[] GetIndustryWheel(IEnumerable<MarketPaper> papers)
        {
            int[] days = { 5, 10, 20, 30, 60, 120, 250 };
            int i;
            Point[] r = null;
            foreach (var p in papers)
            {
                PaperMa[] ma = new PaperMa[days.Length];
                for (i = 0; i < days.Length; i++)
                    ma[i] = _maService.GetMa(p, days[i]);

                if (ma[^1].Prices.Length == 0)
                    continue;

                OrderedCalcPaperWheel paperWheel = new OrderedCalcPaperWheel(ma, p);

                if (r == null)
                    r = new Point[paperWheel.GetCount()];

                i = 0;
                DateTime time = ma[^1].Prices[0].Time;
                foreach (var item in p.ExchangeInfo)
                {
                    if (item.Date >= time)
                    {
                        r[i].Time = item.Date;
                        r[i++].Value += paperWheel.CalcuteWeight(item.Date, item.Price.Close);
                    }
                }
            }

            for (i = 0; i < r?.Length; i++)
            {
                r[i].Value /= papers.Count();
            }

            return r;
        }
    }
}
