using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WrapperAPI.Models.EcomailModels;

namespace WrapperAPI.Repositories
{
    public interface IEcomailRepository
    {
        Task<string> CreateSubscriber(Subscriber subscriber);
        Task<string> UpdateSubscriber(string mail);
        Task<string> DeleteSubscriber(string mail);
    }
}
