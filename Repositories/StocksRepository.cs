using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IIStocksRepository 
    {
        Task<Stock> GetStockAsync(Guid id);
        Task <IEnumerable<Stock>> GetStocksAsync();
        Task CreateStockAsync(Stock stock);
        Task UpdateStockAsync(Stock stock);
        Task DeleteStockAsync(Guid id);
    }
}