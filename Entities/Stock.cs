using System;
namespace Catalog.Entities
{
    public record Stock
    {
        public Guid Id {get; init;}
        public string Acronym {get;init;}
        public string Company {get; init;}
        public decimal Price {get;set;}
        public double closingRate {get; set;}
        public double rangeOfDay {get; set;}
        public double rangeOfYear {get; set;}
        public double capitalization {get; set;}
        public double marketVolume {get; set;}
        public string marketPlaceHolder {get; init;}
        public DateTimeOffset LastTimeUpdate {get; init;}

    }

}