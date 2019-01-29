using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Abstractions
{
    /// <summary>
    /// IConnector interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IConnector<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetRestEntitiesAsync(string query);

        Task<ICollection<T>> GetWSEntities();

    }
}
