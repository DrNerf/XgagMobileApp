using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceLayer
{
    internal class AuthenticationProxy : ProxyBase<IUserSessionModel, UserSessionModel>, IAuthenticationProxy
    {
        private string m_ControllerAddress;
        private IUnityContainer m_Container;

        public AuthenticationProxy(
            IUnityContainer container,
            IUserSessionModel userSession)
            : base(string.Empty, userSession)
        {
            m_Container = container;
        }

        public Task<bool> Login(string username, string password)
        {
            return SafeExecute<bool>(() =>
            {
                var isSuccess = false;

                using (var client = CreateHttpClient())
                {
                    var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("UserName", username),
                        new KeyValuePair<string, string>("Password", password),
                        new KeyValuePair<string, string>("RememberMe", false.ToString()),
                    });
                    var result = client.PostAsync($"{Constants.APIBaseAddress}Auth/Login", content).Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        var session = JsonConvert.DeserializeObject<UserSessionModel>(json);
                        m_Container.RegisterInstance<IUserSessionModel>(session);
                        isSuccess = true;
                    }
                };

                return isSuccess;
            });
        }

        public Task Logoff()
        {
            throw new NotImplementedException();
        }
    }
}
