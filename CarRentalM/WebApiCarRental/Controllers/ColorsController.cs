using Business.Abstract;
using Entities.Concrete;
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
  
        public class ColorsController : ControllerBase
        {
            private readonly IColorService _colorService;

            public ColorsController(IColorService colorService)
            {
                _colorService = colorService;
            }



            //All color
            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _colorService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

           

            //Add
            [HttpPost("add")]
            public IActionResult Add(Color color)
            {
                var result = _colorService.Add(color);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }

            //Delete
            [HttpPost("delete")]
            public IActionResult Delete(Color color)
            {
                var result = _colorService.Delete(color);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }

            //Update
            [HttpPost("update")]
            public IActionResult Update(Color color)
            {
                var result = _colorService.Update(color);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
        }
    
}
