using _3maVision.Domain.Entities;
using _3maVision.Domain.Interfaces;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3maVision.Infrastructure.Data
{
    public class TableStorageOrderBookRepository : IOrderBookRepository
    {
        private readonly string _connectionString;

        public TableStorageOrderBookRepository(IConfiguration configuration)
        {
            _connectionString = configuration["AzureTableStorage:ConnectionString"];
        }

        public async Task<IEnumerable<OrderBook>> GetOrderBooksAsync(string symbol, string date, int depth)
        {
            string tableName = $"{symbol}Depth{depth}";
            var tableClient = new TableClient(_connectionString, tableName);
            await tableClient.CreateIfNotExistsAsync();

            var query = tableClient.QueryAsync<OrderBookTableEntity>(filter: $"PartitionKey eq '{date}'");
            var results = new List<OrderBook>();

            await foreach (var entity in query)
            {
                results.Add(entity.ToDomain());
            }

            return results;
        }
    }
}
