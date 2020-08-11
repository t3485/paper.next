using Microsoft.EntityFrameworkCore;
using Paper.EntityFrameworkCore;
using Paper.Enums;
using Paper.Papers;
using Paper.Papers.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paper.Repository
{
    public class PaperRepository : EfCoreRepository<PaperDbContext, MarketPaper, int>, IPaperRepository
    {
        public PaperRepository(IDbContextProvider<PaperDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<MarketPaper> GetIncludePriceAsync(DateTime b, DateTime e, PaperPriceType type, string code)
        {
            var paper = await DbContext.Set<MarketPaper>()
                .SingleAsync(x => x.Code == code);

            if (type == PaperPriceType.Day)
            {
                var price = await DbContext.Set<PaperDayPricePoint>()
                    .Where(x => x.Date >= b && x.Date <= e).ToListAsync();
            }

            return paper;
        }

        public async Task<List<MarketPaper>> GetAllIncludePriceAsync(DateTime b, DateTime e, PaperPriceType type)
        {
            var paper = await DbContext.Set<MarketPaper>().ToListAsync();

            List<PaperPricePoint> price = null;
            if (type == PaperPriceType.Day)
            {
                price = await DbContext.Set<PaperDayPricePoint>()
                    .AsNoTracking()
                    .Where(x => x.Date >= b && x.Date <= e)
                    .Select(x => new PaperPricePoint(x.Code, x.Date, new PaperPrice(x.Price.Close)))
                    .ToListAsync();
            }
            else if (type == PaperPriceType.Week)
            {
                price = await DbContext.Set<PaperWeekPricePoint>()
                    .AsNoTracking()
                    .Where(x => x.Date >= b && x.Date <= e)
                    .Select(x => new PaperPricePoint(x.Code, x.Date, new PaperPrice(x.Price.Close)))
                    .ToListAsync();
            }
            SetPaperPrice(paper, price);

            return paper;
        }

        private void SetPaperPrice(List<MarketPaper> papers, List<PaperPricePoint> data)
        {
            if (data != null)
            {
                var dict = papers.ToDictionary(x => x.Code);

                foreach (var item in data.GroupBy(x => x.Code))
                {
                    if (dict.TryGetValue(item.Key, out var p))
                        p.SetPrice(item.ToArray());
                }
            }
        }
    }
}
