using _3maVision.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Application.Interfaces
{
    public interface IOrderBookService
    {
        Task<IEnumerable<OrderBookAggregateDto>> GetAggregatedOrderBooksAsync(
            string symbol, string date, int depth, string timeInterval);
    }
}
