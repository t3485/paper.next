using Paper.Papers.MA;
using Paper.Papers.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Services;

namespace Paper.Papers
{
    public class PaperMaService : ApplicationService, IPaperMaService
    {
        public PaperMa GetMa(MarketPaper paper, int n)
        {
            if (paper == null)
                throw new ArgumentNullException(nameof(paper));
            if (n <= 0)
                throw new ArgumentException(nameof(n));

            if (paper.ExchangeInfo == null || paper.ExchangeInfo.Count < n)
                return new PaperMa(n);

            // TODO: 保证数据已排序，连续
            return new PaperMa(n, GetMa(paper.ExchangeInfo, n));
        }

        private List<Point> GetMa(ICollection<PaperPricePoint> price, int n)
        {
            PaperPricePoint[] array = price.ToArray();
            List<Point> ma = new List<Point>();

            decimal sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i].Price.Close;
                if (i < n - 1)
                    continue;
                ma.Add(new Point(array[i].Date, sum));
                sum -= array[i - n + 1].Price.Close;
            }
            return ma;
        }
    }
}
