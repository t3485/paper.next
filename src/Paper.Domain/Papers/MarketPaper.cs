using Paper.Papers.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Paper.Papers
{
    public class MarketPaper : AggregateRoot<int>
    {
        public virtual string Code { get; protected set; }

        public virtual string FullName { get; protected set; }

        public virtual string SimpleName { get; protected set; }

        public virtual string Exchange { get; protected set; }

        public virtual DateTime MarketTime { get; protected set; }

        public virtual string Industry { get; protected set; }

        [NotMapped]
        public virtual ICollection<PaperPricePoint> ExchangeInfo { get; protected set; }

        protected MarketPaper() { }

        public MarketPaper(string code, string fullName)
        {
            Code = code;
            FullName = fullName;
            SimpleName = fullName;
        }

        public void SetPrice(ICollection<PaperPricePoint> exchangeInfo)
        {
            ExchangeInfo = exchangeInfo;
        }
    }
}
