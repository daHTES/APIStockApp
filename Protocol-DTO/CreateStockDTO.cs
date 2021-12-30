using System.ComponentModel.DataAnnotations;

namespace Catalog.StocksDTO
{

    public record CreateStockDTO
    {
        [Required]
        public string Acronym {get;init;}
        [Required]
        [Range(1, 5000)]
        public decimal Price {get;set;}
        [Required]
        public string Company {get; set;}
        [Required]
        [Range(1, 5000)]
        public double closingRate{get; set;}
    }
}