using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories 
{
    public class MongoDbStocksRepository : IIStocksRepository
    {
        private const string databaseStockName = "StockExchange";
        private const string collectionStocksName = "stocks";
        private readonly IMongoCollection<Stock> stocksCollection;
        
        private readonly FilterDefinitionBuilder<Stock> filterBuilder = Builders<Stock>.Filter;

        public MongoDbStocksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseStockName);
            stocksCollection = database.GetCollection<Stock>(collectionStocksName);
        }
        public async Task CreateStockAsync(Stock stock)
        {
            await stocksCollection.InsertOneAsync(stock);
        }

        public async Task DeleteStockAsync(Guid id)
        {
            var filter = filterBuilder.Eq(stock => stock.Id, id);
            await stocksCollection.DeleteOneAsync(filter);
        }

        public async Task<Stock> GetStockAsync(Guid id)
        {
            var filter = filterBuilder.Eq(stock => stock.Id, id);
            return await stocksCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            return await stocksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateStockAsync(Stock stock)
        {
             var filter = filterBuilder.Eq(existingStock => existingStock.Id, stock.Id);
             await stocksCollection.ReplaceOneAsync(filter, stock);
        }
    }
}