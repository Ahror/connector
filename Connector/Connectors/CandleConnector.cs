using Connector.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Connector.Connectors
{
    public class CandleConnector : BaseConnector<Candle>
    {
        /// <summary>
        /// Deserializing result from Api to Candle entity list
        /// </summary>
        protected override ICollection<Candle> Deserialize(string json, string query)
        {
            ICollection<Candle> candles = new List<Candle>();
            JArray jarray = (JArray)JsonConvert.DeserializeObject(json);
            if (jarray != null)
            {
                if (query.Contains("hist"))
                {
                    foreach (JArray item in jarray)
                    {
                        candles.Add(GenerateCandle(item));
                    }
                }
                else
                {
                    candles.Add(GenerateCandle(jarray));
                }
            }
            return candles;
        }

        private Candle GenerateCandle(JArray item)
        {
            return new Candle
            {
                MTS = (long)item[0],
                Open = (float)item[1],
                Close = (float)item[2],
                High = (float)item[3],
                Low = (float)item[4],
                Volume = (float)item[5]
            };
        }
    }
}
