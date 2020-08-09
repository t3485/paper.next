using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers
{
    public class Industry
    {
        public virtual ICollection<MarketPaper> Paper { get; protected set; }

        public Industry(ICollection<MarketPaper> paper)
        {
            Paper = paper;
        }
    }
}
