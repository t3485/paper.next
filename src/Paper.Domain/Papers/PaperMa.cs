using Paper.Papers.Price;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers
{
    public class PaperMa
    {
        public int Cycle { get; protected set; }

        public ICollection<PaperPricePoint> Prices { get; protected set; }

        protected PaperMa() { }

        public PaperMa(int cycle, ICollection<PaperPricePoint> prices)
        {
            Cycle = cycle;
            Prices = prices;

            if (Prices == null)
                throw new Exception(nameof(Prices));
        }
    }
}
