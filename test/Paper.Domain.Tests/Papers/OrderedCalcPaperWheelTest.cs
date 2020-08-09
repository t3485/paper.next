using Paper.Papers.MA;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paper.Papers
{
    public class OrderedCalcPaperWheelTest : PaperDomainTestBase
    {
        [Fact]
        public void Should_Get_Start_Index()
        {
            int total = 100;
            DateTime now = new DateTime(2020, 6, 1);
            PaperMa[] ma = new PaperMa[5];
            MarketPaper p = new MarketPaper("000001", "忘了是啥");

            for (int i = 0; i < 5; i++)
            {
                Point[] points = new Point[total / i];
                for (int j = 0; j < points.Length; j++)
                {
                    points[j].Time = now.AddDays(j - points.Length + 1);
                    points[j].Value = j;
                }
                ma[i] = new PaperMa(i, points);
            }

            OrderedCalcPaperWheelTestWrapper wheel = new OrderedCalcPaperWheelTestWrapper(ma, p);
            wheel.GetStartIndexTest(ma[0], now)
                .ShouldBe(total - 1);
        }

        internal class OrderedCalcPaperWheelTestWrapper : OrderedCalcPaperWheel
        {
            public OrderedCalcPaperWheelTestWrapper(PaperMa[] ma, MarketPaper paper) : base(ma, paper)
            { }

            public int GetStartIndexTest(PaperMa ma, DateTime time)
            {
                return base.GetStartIndex(ma, time);
            }
        }
    }
}
