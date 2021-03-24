using Business.Abstarct;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        //ADD
        [HttpPost("add")]
        public IActionResult PostAdd(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //DELETE
        [HttpPost("delete")]
        public IActionResult PostDelete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //UPDATE
        [HttpPost("update")]
        public IActionResult PostUpdate(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //GETALL
        [HttpGet("getall")]
        public IActionResult Get()
        {
            Thread.Sleep(1000);//sleep for 1 sec
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcolorsbybrandid")]
        public IActionResult GetColorsByBrandId(int brandId)
        {
            var result = _colorService.GetColorsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}