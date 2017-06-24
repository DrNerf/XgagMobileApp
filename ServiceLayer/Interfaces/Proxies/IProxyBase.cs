using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IProxyBase<T>
    {
        Task<IEnumerable<T>> Get(IEnumerable<KeyValuePair<string, string>> query = null);
    }
}
