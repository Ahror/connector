using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Abstractions
{
    public interface IConnector<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetRestEntitiesAsync(string query);

        Task<ICollection<T>> GetWSEntities();

    }
}
