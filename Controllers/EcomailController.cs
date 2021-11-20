using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrapperAPI.Repositories;
using static WrapperAPI.Models.EcomailModels;

namespace WrapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcomailController : ControllerBase
    {
        private readonly IEcomailRepository _wrapperRepository;

        public EcomailController(IEcomailRepository ecomailRepository)
        {
            _wrapperRepository = ecomailRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddSubscriber([FromBody] Subscriber subscriber)
        {
            var newSubscriber = await _wrapperRepository.CreateSubscriber(subscriber);

            if (newSubscriber != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpPatch("{mail}")]
        //public async Task<ActionResult<ListCollection>> UpdateSubscriber(string mail, Subscriber subscriber)
        //{
        //    return await _ecomailRepository.GetLists();
        //}

        //[HttpDelete("{mail}")]
        //public async Task<ActionResult<ListCollection>> DeleteSubscriber(string mail)
        //{
        //    var subscriber = await _ecomailRepository.DeleteSubscriber(mail);
        //    return await _ecomailRepository.GetLists();
        //}
    }
}
