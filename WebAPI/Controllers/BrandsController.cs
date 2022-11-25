using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
