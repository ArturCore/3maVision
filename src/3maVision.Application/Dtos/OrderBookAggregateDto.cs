using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Application.Dtos
{
    public class OrderBookAggregateDto
    {
        public DateTimeOffset Timestamp { get; set; }
        public double AvgPrice { get; set; }
        public double TotalAskVolume { get; set; }
        public double TotalBidVolume { get; set; }
        public double AvgDelta { get; set; }
    }
}
