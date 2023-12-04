using HotelListing.API.Models.Hotels;

namespace HotelListing.API.Models.Countries
{   
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
