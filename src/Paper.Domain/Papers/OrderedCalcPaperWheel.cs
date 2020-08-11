using Paper.Papers.MA;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers
{
    public class OrderedCalcPaperWheel
    {
        private MarketPaper _paper;
        private PaperMa[] _ma;
        private int start;

        public OrderedCalcPaperWheel(PaperMa[] ma, MarketPaper paper)
        {
            _paper = paper;
            _ma = ma;
            start = _ma[^1].Prices.Length;
        }

        public decimal CalcuteWeight(Point point)
        {
            return CalcuteWeight(point.Time, point.Value);
        }

        public decimal CalcuteWeight(DateTime time, decimal price)
        {
            for (int i = _ma.Length - 1; i >= 0; i--)
            {
                var f = GetStartIndex(_ma[i], time);
                if (f != -1 && price > _ma[i].Prices[f].Value)
                    return i;
            }
            return 0;
        }

        public int GetCount()
        {
            return _ma[^1].Prices.Length;
        }

        protected int GetStartIndex(PaperMa ma, DateTime time)
        {
            int i = ma.Prices.Length - start;
            for (; i < ma.Prices.Length; i++)
                if (ma.Prices[i].Time == time)
                    break;
            start = ma.Prices.Length - i;

            return i == ma.Prices.Length ? -1 : i;
        }
    }
}
