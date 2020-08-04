using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers.Price
{
    public class PaperDayPricePoint : PaperPricePoint
    {
        protected PaperDayPricePoint() { }

        public PaperDayPricePoint(string code, DateTime date, PaperPrice price) 
            : base(code, date, price)
        { }
    }
}
