using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paper.Papers.Price
{
    [Owned]
    public class PaperPrice
    {
        public virtual decimal Open { get; protected set; }

        public virtual decimal Close { get; protected set; }

        public virtual decimal High { get; protected set; }

        public virtual decimal Low { get; protected set; }

        public virtual decimal Turn { get; protected set; }

        public virtual decimal Chg { get; protected set; }

        protected PaperPrice() { }

        public PaperPrice(decimal close) { Close = close; }
    }
}
