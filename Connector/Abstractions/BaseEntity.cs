namespace Connector.Abstractions
{
    /// <summary>
    /// Base class for trade and candle 
    /// </summary>
    public class BaseEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// Millisecond time stamp
        /// </summary>
        public long MTS { get; set; }
    }
}
