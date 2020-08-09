using Microsoft.EntityFrameworkCore;
using Paper.EntityFrameworkCore;
using Paper.Papers;
using System;
using System.Collections.Generic;
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

        public async Task<MarketPaper> GetIncludePriceAsync(DateTime b, DateTime e, string code = null)
        {

            var paper = await DbContext.Set<MarketPaper>()
                .SingleAsync(x => x.Code == code);


            DbContext.Entry(paper)
              .Collection(b => b.ExchangeInfo)
              .Load();

            return paper;
        }
    }
}
