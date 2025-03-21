using _3maVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Infrastructure.Data
{
    public static class OrderBookTableEntityExtensions
    {
        public static OrderBook ToDomain(this OrderBookTableEntity tableEntity)
        {
            return new OrderBook
            {
                PartitionKey = tableEntity.PartitionKey,
                RowKey = tableEntity.RowKey,
                Timestamp = tableEntity.Timestamp.GetValueOrDefault(),
                Symbol = tableEntity.Symbol,
                Date = tableEntity.Date,
                AskVolume = tableEntity.AskVolume,
                BidVolume = tableEntity.BidVolume,
                Price = tableEntity.Price,
                Amount = tableEntity.Amount,
                Delta = tableEntity.Delta,
                A7 = tableEntity.A7,
                DepthPercentage = tableEntity.DepthPercentage
            };
        }
    }
}
