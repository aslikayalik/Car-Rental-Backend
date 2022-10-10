using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize] 
    public class UsersController : ControllerBase
    {
        private  IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //All User
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

       

        //Add
        [HttpGet("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        //delete
        [HttpGet("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        //Update
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            // var result = _userService.Update(user, user.password);
            /* if (result.Success)
             {
                 return Ok(result);
             }
             return BadRequest(result);*/
            return Ok();
        }

        //Get Claim
        [HttpGet("getclaim")]
        public IActionResult
            GetClaim(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        //Get User  
        [HttpGet("getuser")]
        public IActionResult GetUser(string email)
        {
            var result = _userService.GetUserAndClaim(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //Get By Email
        [HttpGet("getbyemail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
