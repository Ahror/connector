using Connector.Model;
using Newtonsoft.Json;
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

        protected override ICollection<Candle> Deserialize(string json, bool istBTCUSD)
        {
            throw new NotImplementedException();
        }
    }
}
