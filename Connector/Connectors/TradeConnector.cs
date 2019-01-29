using System.Collections.Generic;
using Connector.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Connector.Connectors
{
    public class TradeConnector : BaseConnector<Trade>
    {
        protected override ICollection<Trade> Deserialize(string json, bool istBTCUSD)
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
                if (istBTCUSD)
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
