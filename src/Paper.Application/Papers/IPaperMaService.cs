using Paper.Papers.MA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers
{
    public interface IPaperMaService
    {
        PaperMa GetMa(MarketPaper paper, int n);
    }
}
