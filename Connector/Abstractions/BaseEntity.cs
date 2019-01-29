using System;
using System.Collections.Generic;
using System.Text;

namespace Connector.Abstractions
{
    public class BaseEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// Millisecond time stamp
        /// </summary>
        public long MTS { get; set; }
    }
}
