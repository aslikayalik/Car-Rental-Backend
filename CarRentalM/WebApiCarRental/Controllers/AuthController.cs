using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(new ErrorResult(userToLogin.Message));
            }


            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExists(userForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
