using Paper.Enums;
using Paper.Papers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paper.Repository
{
    public interface IPaperRepository : IRepository<MarketPaper, int>
    {
        Task<MarketPaper> GetIncludePriceAsync(DateTime b, DateTime e, PaperPriceType type, string code);

        Task<List<MarketPaper>> GetAllIncludePriceAsync(DateTime b, DateTime e, PaperPriceType type);
    }
}
