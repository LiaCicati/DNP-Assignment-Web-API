using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("adults")]
    public class AdultsController : ControllerBase
    {
        private IAdultRepository _adultRepository;

        public AdultsController(IAdultRepository adultRepository)
        {
            this._adultRepository = adultRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await _adultRepository.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult added = await _adultRepository.AddAdultAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{adultId:int}")]
        public async Task<ActionResult<Adult>> RemoveAdult([FromRoute] int adultId)

        {
            try
            {
                Adult removedAdult = await _adultRepository.RemoveAdultAsync(adultId);
                return Ok(removedAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}