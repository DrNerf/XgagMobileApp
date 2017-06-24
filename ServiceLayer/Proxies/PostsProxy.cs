using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal class PostsProxy : ProxyBase<IPostModel, PostModel>, IPostsProxy
    {
        private const int m_PageSize = 5;

        public PostsProxy(string service)
            : base(service)
        {
        }

        public async Task<IEnumerable<IPostModel>> Get(int page)
        {
            var query = new List<KeyValuePair<string, string>>();
            int skip = 0;
            if (page > 1)
            {
                skip = (page - 1) * m_PageSize;
            }

            query.Add(new KeyValuePair<string, string>("skip", skip.ToString()));
            query.Add(new KeyValuePair<string, string>("take", m_PageSize.ToString()));
            return await base.Get(query);
        }
    }
}
