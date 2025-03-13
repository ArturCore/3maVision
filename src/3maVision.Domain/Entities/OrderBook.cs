﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Domain.Entities
{
    public class OrderBook
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Symbol { get; set; }
        public string Date { get; set; }
        public double AskVolume { get; set; }
        public double BidVolume { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Delta { get; set; }
        public double A7 { get; set; }
        public int DepthPercentage { get; set; }
    }
}
