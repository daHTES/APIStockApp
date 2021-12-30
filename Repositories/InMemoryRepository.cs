using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class InMemoryStocksRepository : IIStocksRepository
    {
        private readonly List<Stock> stocks = new()
        {
            new Stock 
            { 
                Id = Guid.NewGuid(), 
                Acronym = "GOOG", 
                Price = 2867, 
                Company = "Alpha Bet", 
                closingRate = 2831.14,
                rangeOfDay = 2810.05,
                rangeOfYear = 1694.00,
                marketVolume = 1.91,
                capitalization = 1.46,
                marketPlaceHolder = "NASDAQ",
                LastTimeUpdate = DateTimeOffset.UtcNow 
            },
            new Stock 
            { 
                Id = Guid.NewGuid(), 
                Acronym = "AMZN", 
                Price = 3341, 
                Company = "Amazon", 
                closingRate = 3341.58,
                rangeOfDay = 3312.95,
                rangeOfYear = 2881.00,
                marketVolume = 1.69,
                capitalization = 3.37,
                marketPlaceHolder = "NASDAQ",
                LastTimeUpdate = DateTimeOffset.UtcNow 

            },
            new Stock 
            { 
                Id = Guid.NewGuid(), 
                Acronym = "ORCL", 
                Price = 91, 
                Company = "Oracle", 
                closingRate = 91.64,
                rangeOfDay = 89.71,
                rangeOfYear = 59.74,
                marketVolume = 250.52,
                capitalization = 10.92,
                marketPlaceHolder = "NASDAQ",
                LastTimeUpdate = DateTimeOffset.UtcNow 
            }
        };

        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            return await Task.FromResult(stocks);
        }

        public async Task<Stock> GetStockAsync(Guid id)
        {
            var stock = stocks.Where(stock => stock.Id == id).SingleOrDefault();
            return await Task.FromResult(stock);
        }

        public async Task CreateStockAsync(Stock stock)
        {
            stocks.Add(stock);
            await Task.CompletedTask;
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            var index = stocks.FindIndex(existingStock => existingStock.Id == stock.Id);
            stocks[index] = stock;
            await Task.CompletedTask;
        }

        public async Task DeleteStockAsync(Guid id)
        {
            var index = stocks.FindIndex(existingStock => existingStock.Id == id);
            stocks.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}