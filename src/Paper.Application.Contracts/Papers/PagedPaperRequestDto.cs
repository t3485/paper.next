using Paper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers
{
    public class PagedPaperRequestDto
    {
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public PaperPriceType Type { get; set; }
    }
}
