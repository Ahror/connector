using Connector.Abstractions;

namespace Connector.Model
{
    public class Trade : BaseEntity
    {
        /// <summary>
        /// How much was bought (positive) or sold (negative).
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Price at which the trade was executed
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Rate at which funding transaction occurred
        /// </summary>
        public float Rate { get; set; }

        /// <summary>
        /// Amount of time the funding transaction was for
        /// </summary>
        public int Period { get; set; }
    }
}
