using Newtonsoft.Json;
using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using static WrapperAPI.Models.WrapperModels;
using static WrapperAPI.Models.EcomailModels;

namespace WrapperAPI
{
    public class Ecomail
    {
        private readonly Uri baseAdress = new Uri("https://api2.ecomailapp.cz/");
        private readonly string APIkey = "6190665a153b56190665a153b6";

        public async Task<string> CreateSubscriberAsync(Subscriber subscriber)
        {
            Wrapper_Subscriber body = new Wrapper_Subscriber
            {
                Subscriber_data = new Subscriber_data
                {
                    Email = subscriber.Email,
                    Name = subscriber.Name,
                    Surname = subscriber.Surname
                }
            };

            using HttpClient httpClient = new HttpClient { BaseAddress = baseAdress };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", APIkey);

            var jsonBody = JsonConvert.SerializeObject(body).ToLower();

            using var content = new StringContent(jsonBody, Encoding.Default, "application/json");
            using var response = await httpClient.PostAsync("lists/1/subscribe", content);
            string responseData = await response.Content.ReadAsStringAsync();

            return responseData;
        }
    }
}
