using Connector.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connector.Connectors
{
    public abstract class BaseConnector<T> : IConnector<T> where T : BaseEntity
    {
        protected HttpClient HttpClient { get; set; }
        public BaseConnector()
        {
            HttpClient = new HttpClient { BaseAddress = new Uri("https://api.bitfinex.com/") };
        }

        protected abstract ICollection<T> Deserialize(string json, bool istBTCUSD);
        public async Task<ICollection<T>> GetRestEntitiesAsync(string query)
        {
            var httpResponse = await HttpClient.GetAsync(query);
            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonData = await httpResponse.Content.ReadAsStringAsync();
                ICollection<T> result = Deserialize(jsonData, query.ToLower().Contains("tbtcusd"));
                return result;
            }
            else
            {
                throw new Exception($"Request has failed: {httpResponse.RequestMessage}");
            }
        }
        public Task<ICollection<T>> GetWSEntities()
        {
            throw new NotImplementedException();
        }
    }
}
