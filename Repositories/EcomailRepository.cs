using Newtonsoft.Json;
using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using static WrapperAPI.Models.EcomailModels;
using static WrapperAPI.Models.WrapperModels;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Configuration;

namespace WrapperAPI
{
    public class EcomailRepository
    {
        private readonly string APIKey = "6190665a153b56190665a153b6";
        private readonly Uri baseUri = new Uri("https://api2.ecomailapp.cz/");

        public async Task<HttpResponseMessage> CreateSubscriberAsync(Subscriber subscriber)
        {
            Ecomail_Subscriber body = new Ecomail_Subscriber
            {
                Subscriber_data = new Subscriber_data
                {
                    Email = subscriber.Email,
                    Name = subscriber.Name,
                    Surname = subscriber.Surname
                }
            };

            using HttpClient httpClient = new HttpClient { BaseAddress = baseUri };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", APIKey);

            var jsonBody = JsonConvert.SerializeObject(body).ToLower();

            using var content = new StringContent(jsonBody, Encoding.Default, "application/json");
            using var response = await httpClient.PostAsync("lists/1/subscribe", content);

            return response;
        }        
        
        public async Task<HttpResponseMessage> DeleteSubscriberAsync(string email)
        {
            using HttpClient httpClient = new HttpClient { BaseAddress = baseUri };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", APIKey);

            using var response = await httpClient.DeleteAsync(String.Format("subscribers/{0}/delete", email));

            return response;
        }
        
        public async Task<int> GetSubscriberAsync(Subscriber subscriber)
        {
            using HttpClient httpClient = new HttpClient { BaseAddress = baseUri };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", APIKey);

            using var response = await httpClient.GetAsync(String.Format("lists/1/subscriber/{0}", subscriber.Email));
            var data = response.Content.ReadAsStringAsync();

            var id = JObject.Parse(data.Result)
                .Descendants()
                .OfType<JObject>()
                .Select(x => (int)x["id"])
                .FirstOrDefault();

            return id;
        }
    }
}
