using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IPostsProxy : IProxyBase<IPostModel>
    {
        Task<IEnumerable<IPostModel>> Get(int page);
    }
}
