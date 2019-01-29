using System.Collections.Generic;
using Connector.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Connector.Connectors
{
    /// <summary>
    /// Trade connector
    /// </summary>
    public class TradeConnector : BaseConnector<Trade>
    {
        /// <summary>
        /// Deserializing result from Api to Trade entity list
        /// </summary>
        /// <param name="json"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        protected override ICollection<Trade> Deserialize(string json, string query)
        {
            ICollection<Trade> trades = new List<Trade>();
            JArray jarray = (JArray)JsonConvert.DeserializeObject(json);

            foreach (JArray item in jarray)
            {
                Trade trade = new Trade
                {
                    Id = (long)item[0],
                    MTS = (long)item[1],
                    Amount = (float)item[2]
                };
                if (query.ToLower().Contains("tbtcusd"))
                {
                    trade.Price = (float)item[3];
                }
                else
                {
                    trade.Rate = (float)item[3];
                    trade.Period = (int)item[4];
                }
                trades.Add(trade);
            }
            return trades;
        }
    }
}
