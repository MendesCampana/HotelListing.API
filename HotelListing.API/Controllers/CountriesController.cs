using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using NuGet.Protocol;
using HotelListing.API.Models.Countries;
using AutoMapper;
using HotelListing.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Models;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        public CountriesController(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            var countriesDto = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(countriesDto);
        } 
        
        // GET: api/Countries/?startindex=0&pagesize=15&pagenumber=1
        [HttpGet("GetPaged")]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountries = await _countryRepository.GetAllAsync<GetCountryDto>(queryParameters);          
            return Ok(pagedCountries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countryRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }
            var countryDto = _mapper.Map<CountryDto>(country);

            return countryDto;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
        {
            if (id != updateCountry.Id)
                return BadRequest();

            var country = await _countryRepository.GetAsync(id);
            if (country == null)
                return NotFound();

            //here we have EF modifying the entity and state for it is 'Modified'
            _mapper.Map(updateCountry, country);

            try
            {
                await _countryRepository.UpdateASync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countryRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null) return NotFound();
            await _countryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countryRepository.Exists(id);
        }
    }
}
