using Connector.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connector.Connectors
{
    /// <summary>
    /// Base class for candle and trade connector
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseConnector<T> : IConnector<T> where T : BaseEntity
    {
        public BaseConnector()
        {
            HttpClient = new HttpClient { BaseAddress = new Uri("https://api.bitfinex.com/") };
        }

        /// <summary>
        /// Http client
        /// </summary>
        protected HttpClient HttpClient { get; set; }

        protected abstract ICollection<T> Deserialize(string json, string query);

        /// <summary>
        /// Getting entity by query from rest
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> GetRestEntitiesAsync(string query)
        {
            var httpResponse = await HttpClient.GetAsync(query);
            if (!httpResponse.IsSuccessStatusCode)
                return new List<T>();

            string jsonData = await httpResponse.Content.ReadAsStringAsync();
            return Deserialize(jsonData, query);
        }

        /// <summary>
        /// Getting entity by query from WebSocket
        /// </summary>
        /// <returns></returns>
        public Task<ICollection<T>> GetWSEntities()
        {
            throw new NotImplementedException();
        }
    }
}
