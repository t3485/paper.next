using System;
using System.Collections.Generic;
using System.Text;

namespace Paper.Papers.MA
{
    public struct Point
    {
        public DateTime Time { get; set; }

        public decimal Value { get; set; }

        public Point(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   Time == point.Time &&
                   Value == point.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, Value);
        }
    }
}
