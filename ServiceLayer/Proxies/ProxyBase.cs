using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal abstract class ProxyBase<TModelInterface, TModelImplementation> : IProxyBase<TModelInterface>
        where TModelImplementation : TModelInterface
    {
        private string m_Service;
        private IUserSessionModel m_UserSession;

        public ProxyBase(
            string service, 
            IUserSessionModel userSession)
        {
            m_Service = service;
            m_UserSession = userSession;
        }

        public virtual Task<IEnumerable<TModelInterface>> Get(IEnumerable<KeyValuePair<string, string>> query = null)
        {
            return SafeExecute<IEnumerable<TModelInterface>>(() =>
            {
                using (HttpClient client = CreateHttpClient())
                {
                    var queryString = new StringBuilder();
                    if (query?.Any() ?? false)
                    {
                        foreach (var queryValue in query)
                        {
                            if (queryString.Length == 0)
                            {
                                queryString.Append('?');
                            }
                            else
                            {
                                queryString.Append('&');
                            }

                            queryString.Append($"{queryValue.Key}={queryValue.Value}");
                        }
                    }

                    var response = client.GetAsync($"{Constants.APIBaseAddress}{m_Service}{queryString}").Result;
                    var json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<TModelImplementation>>(json).Cast<TModelInterface>();
                }
            });
        }

        protected HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (m_UserSession.SessionToken != default(Guid))
            {
                client.DefaultRequestHeaders.Add("SessionToken", m_UserSession.SessionToken.ToString()); 
            }

            return client;
        }

        protected Task<T> SafeExecute<T>(Func<T> method)
        {
            var methodTask = new Task<T>(method);
            methodTask.Start();
            return methodTask;
        }
    }
}
