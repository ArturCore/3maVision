using _3maVision.Application.Dtos;
using _3maVision.Application.Interfaces;
using _3maVision.Domain.Entities;
using _3maVision.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Application.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderBookRepository _orderBookRepository;

        public OrderBookService(IOrderBookRepository orderBookRepository)
        {
            _orderBookRepository = orderBookRepository;
        }

        public async Task<IEnumerable<OrderBookAggregateDto>> GetAggregatedOrderBooksAsync(
            string symbol, string date, int depth, string timeInterval)
        {
            var orderBooks = await _orderBookRepository.GetOrderBooksAsync(symbol, date, depth);
            return AggregateData(orderBooks, timeInterval);
        }

        private IEnumerable<OrderBookAggregateDto> AggregateData(IEnumerable<OrderBook> data, string timeInterval)
        {
            TimeSpan interval = timeInterval switch
            {
                "5m" => TimeSpan.FromMinutes(5),
                "15m" => TimeSpan.FromMinutes(15),
                "30m" => TimeSpan.FromMinutes(30),
                "1h" => TimeSpan.FromHours(1),
                _ => TimeSpan.FromMinutes(5)
            };

            return data
                .GroupBy(d => d.Timestamp.RoundDown(interval))
                .Select(g => new OrderBookAggregateDto
                {
                    Timestamp = g.Key,
                    AvgPrice = g.Average(x => x.Price),
                    TotalAskVolume = g.Sum(x => x.AskVolume),
                    TotalBidVolume = g.Sum(x => x.BidVolume),
                    AvgDelta = g.Average(x => x.Delta)
                })
                .OrderBy(x => x.Timestamp);
        }
    }

    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset RoundDown(this DateTimeOffset dt, TimeSpan ts)
        {
            return new DateTimeOffset(dt.Ticks - (dt.Ticks % ts.Ticks), dt.Offset);
        }
    }
}
