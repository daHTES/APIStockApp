using Catalog.Entities;
using Catalog.StocksDTO;

namespace Catalog 
{
    public static class Extensions 
    {
        public static StocksDTOs AsDtos(this Stock stock )
        {
            return new StocksDTOs         
            {
                Id = stock.Id,
                Acronym = stock.Acronym,
                Company = stock.Company,
                closingRate = stock.closingRate,
                rangeOfDay = stock.rangeOfDay,
                rangeOfYear = stock.rangeOfYear,
                capitalization = stock.capitalization,
                marketVolume = stock.marketVolume,
                marketPlaceHolder = stock.marketPlaceHolder,
                Price = stock.Price,
                LastTimeUpdate = stock.LastTimeUpdate
            };
        }
    }
}