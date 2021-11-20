using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrapperAPI.Repositories;
using static WrapperAPI.Models.WrapperModels;

namespace WrapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WrapperController : ControllerBase
    {
        private readonly IWrapperRepository _ecomailRepository;

        public WrapperController(IWrapperRepository ecomailRepository)
        {
            _ecomailRepository = ecomailRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddSubscriber([FromBody] Subscriber subscriber)
        {
            var subscriberId = await _ecomailRepository.GetSubscriberAsync(subscriber);

            if (subscriberId > 0) return BadRequest();

            var response = await _ecomailRepository.CreateSubscriberAsync(subscriber);

            if (!response.IsSuccessStatusCode) return BadRequest();

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateSubscriber([FromBody] Subscriber subscriber)
        {
            var subscriberId = await _ecomailRepository.GetSubscriberAsync(subscriber);

            if (subscriberId > 0)
            {
                var response = await _ecomailRepository.CreateSubscriberAsync(subscriber);

                if (!response.IsSuccessStatusCode) return BadRequest();

                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{mail}")]
        public async Task<ActionResult> DeleteSubscriber(string mail)
        {
            var subscriberStatus = await _ecomailRepository.DeleteSubscriberAsync(mail);

            if (!subscriberStatus.IsSuccessStatusCode) return BadRequest();

            return Ok();
        }
    }
}
