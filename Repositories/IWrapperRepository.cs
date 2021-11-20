using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static WrapperAPI.Models.WrapperModels;

namespace WrapperAPI.Repositories
{
    public interface IWrapperRepository
    {
        Task<HttpResponseMessage> CreateSubscriberAsync(Subscriber subscriber);
        Task<HttpResponseMessage> DeleteSubscriberAsync(string mail);
        Task<int> GetSubscriberAsync(Subscriber subscriber);
    }
}
