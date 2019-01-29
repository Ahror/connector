using Connector.Abstractions;

namespace Connector.Model
{
    public class Candle : BaseEntity
    {
        /// <summary>
        /// First execution during the time frame
        /// </summary>
        public float Open { get; set; }

        /// <summary>
        /// Last execution during the time frame
        /// </summary>
        public float Close { get; set; }

        /// <summary>
        /// Highest execution during the time frame
        /// </summary>
        public float High { get; set; }

        /// <summary>
        /// Lowest execution during the timeframe
        /// </summary>
        public float Low { get; set; }

        /// <summary>
        /// Quantity of symbol traded within the timeframe
        /// </summary>
        public float Volume { get; set; }
    }
}
