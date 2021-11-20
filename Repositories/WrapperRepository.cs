using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WrapperAPI.Models;
using static WrapperAPI.Models.WrapperModels;

namespace WrapperAPI.Repositories
{
    public class WrapperRepository : IWrapperRepository
    {
        public async Task<HttpResponseMessage> CreateSubscriberAsync(Subscriber subscriber)
        {
            var caller = new EcomailRepository();

            var result = await caller.CreateSubscriberAsync(subscriber);
            return result;
        }
        
        public async Task<HttpResponseMessage> DeleteSubscriberAsync(string email)
        {
            var caller = new EcomailRepository();

            var result = await caller.DeleteSubscriberAsync(email);
            return result;
        }
        
        public async Task<int> GetSubscriberAsync(Subscriber subscriber)
        {
            var caller = new EcomailRepository();

            int subscriberId = await caller.GetSubscriberAsync(subscriber);
            return subscriberId;
        }
    }
}
