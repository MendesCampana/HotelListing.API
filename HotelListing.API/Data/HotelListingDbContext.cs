using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> HotelS { get; set; }
        public DbSet<Country> Countries  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData([          
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Ukraine",
                    ShortName = "UKR"
                }]);

            modelBuilder.Entity<Hotel>().HasData([
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
