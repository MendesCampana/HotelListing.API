using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData([
                new Hotel
                {
                    Id = 1,
                    Name = "Sunrise Beach",
                    Address = "RedSeaBeach, 101",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Grand Paladium",
                    Address = "Caymann 201",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Small Paladium",
                    Address = "Zizzics 11",
                    CountryId = 3,
                    Rating = 5
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Trash Palace",
                    Address = "Samps 666",
                    CountryId = 1,
                    Rating = 2
                }]);
        }
    }
}
