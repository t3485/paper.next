using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Paper.Papers.Price
{
    public class PaperPricePoint : Entity<int>
    {
        public virtual string Code { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        public virtual PaperPrice Price { get; protected set; }

        protected PaperPricePoint()
        {
        }

        public PaperPricePoint(string code, DateTime date, PaperPrice price)
        {
            Code = code;
            Date = date;
            Price = price;
        }
    }
}
