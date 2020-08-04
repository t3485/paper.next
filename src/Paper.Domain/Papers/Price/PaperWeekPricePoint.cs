using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers.Price
{
    public class PaperWeekPricePoint : PaperPricePoint
    {
        protected PaperWeekPricePoint() { }

        public PaperWeekPricePoint(string code, DateTime date, PaperPrice price) 
            : base(code, date, price)
        { }
    }
}
