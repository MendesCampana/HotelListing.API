﻿using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Models.Countries;
using HotelListing.API.Models.Hotels;

namespace HotelListing.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        { 
            CreateMap<Country,CreateCountryDto>().ReverseMap();
            CreateMap<Country,GetCountryDto>().ReverseMap();
            CreateMap<Country,CountryDto>().ReverseMap();
            CreateMap<Country,UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
        }
    }
}