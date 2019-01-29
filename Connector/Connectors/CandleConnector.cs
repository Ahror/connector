using Connector.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.Connectors
{
    public class CandleConnector : BaseConnector<Candle>
    {
        public CandleConnector()
        {

        }

        protected override ICollection<Candle> Deserialize(string json, string query)
        {
            ICollection<Candle> candles = new List<Candle>();
            JArray jarray = (JArray)JsonConvert.DeserializeObject(json);

            if (query.Contains("hist"))
            {
                foreach (JArray item in jarray)
                {
                    Candle candle = new Candle
                    {
                        MTS = (long)item[0],
                        Open = (float)item[1],
                        Close = (float)item[2],
                        High = (float)item[3],
                        Low = (float)item[4],
                        Volume = (float)item[5]
                    };

                    candles.Add(candle);
                }
            }
            else
            {
                Candle candle = new Candle
                {
                    MTS = (long)jarray[0],
                    Open = (float)jarray[1],
                    Close = (float)jarray[2],
                    High = (float)jarray[3],
                    Low = (float)jarray[4],
                    Volume = (float)jarray[5]
                };

                candles.Add(candle);
            }

            return candles;
        }
    }
}
