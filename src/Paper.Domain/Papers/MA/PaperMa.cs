using Paper.Papers.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paper.Papers.MA
{
    public class PaperMa
    {
        public int Cycle { get; protected set; }

        public Point[] Prices { get; protected set; }

        protected PaperMa() { }

        public PaperMa(int cycle)
        {
            Cycle = cycle;
            Prices = new Point[0];
        }

        public PaperMa(int cycle, ICollection<Point> prices)
        {
            if (Prices == null)
                throw new ArgumentNullException(nameof(Prices));

            Cycle = cycle;
            Prices = prices.ToArray();
        }
    }
}
