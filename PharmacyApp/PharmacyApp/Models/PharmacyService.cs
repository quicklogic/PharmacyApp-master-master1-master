using Newtonsoft.Json;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class PharmacyService
    {
        public object Navigation { get; private set; }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Product>> Get()
        {

           HttpClient client = GetClient();
           string result = await client.GetStringAsync("http://pharmacyapiprototype123.azurewebsites.net/api/products");
           return JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
           
        }

        public async Task<UserInfo> Add(UserInfo user)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync("http://pharmacyapiprototype123.azurewebsites.net/api/user",
                new StringContent(
                    JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            return null;

        }


        public async Task<User> Login(User user)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync("http://pharmacyapiprototype123.azurewebsites.net/api/login",
                new StringContent(
                    JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return null;
            
        }

    }
}
