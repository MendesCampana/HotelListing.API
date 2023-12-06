﻿using HotelListing.API.Contracts;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAuthManager _authManager;
        public AccountController(IAuthManager authManager)
        {
            _authManager = authManager;                
        }
        //POST : api/account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            var errorrs = await _authManager.Register(apiUserDto);
            if (errorrs.Any())
            {
                foreach(var error in errorrs)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }
        //POST : api/account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
           var isValidUser = await _authManager.Login(loginDto);
            if (!isValidUser)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}