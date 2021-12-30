using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;
using Catalog.StocksDTO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Catalog.Controllers 
{
    [ApiController]
    [Route("stocks")]
    public class StocksController : ControllerBase    
    {
        private readonly IIStocksRepository repository;
        private readonly ILogger<StocksController> logger;

        public StocksController(IIStocksRepository repository, ILogger<StocksController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<StocksDTOs>> GetStocksAsync()
        {
                var stocks = (await repository.GetStocksAsync())
                .Select(stocks => stocks.AsDtos());

                logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved{stocks.Count()} stocks");

                return stocks;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StocksDTOs>> GetStockAsync(Guid id)
        {
            var stock = await repository.GetStockAsync(id);
            if (stock is null )
            {
                return NotFound();
            }
            return stock.AsDtos();
        }


        [HttpPost]   
        public async Task<ActionResult<StocksDTOs>> CreateStockAsync(CreateStockDTO stockDTO)
        {
                    Stock stock = new() 
                    {
                        Id = Guid.NewGuid(),
                        Acronym = stockDTO.Acronym,
                        Price = stockDTO.Price,
                        LastTimeUpdate = DateTimeOffset.UtcNow,
                        Company = stockDTO.Company,
                        closingRate = stockDTO.closingRate
                    };

                    await repository.CreateStockAsync(stock);

                    return CreatedAtAction(nameof(GetStockAsync), new {id = stock.Id}, stock.AsDtos());
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> UpdateStockAsync(Guid id, UpdateStockDTO stockDTO)
        {
                var existingStock = await repository.GetStockAsync(id);
                if (existingStock is null)
                {
                    return NotFound();
                }
                Stock updateStock = existingStock with 
                {
                    Acronym = stockDTO.Acronym,
                    Price = stockDTO.Price,
                    Company = stockDTO.Company,
                    closingRate = stockDTO.closingRate
                };
                await repository.UpdateStockAsync(updateStock);
                return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStockAsync(Guid id)
        {
                var existingStock = await repository.GetStockAsync(id);

                if (existingStock is null)
                {
                    return NotFound();
                }

                await repository.DeleteStockAsync(id);
                return NoContent();
        }
    }
}