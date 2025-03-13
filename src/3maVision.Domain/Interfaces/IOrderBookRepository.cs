using _3maVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Domain.Interfaces
{
    public interface IOrderBookRepository
    {
        Task<IEnumerable<OrderBook>> GetOrderBooksAsync(string symbol, string date, int depth);
    }
}
