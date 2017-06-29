using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Authentication Proxy.
    /// </summary>
    public interface IAuthenticationProxy
    {
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Session model.</returns>
        Task<bool> Login(string username, string password);

        /// <summary>
        /// Logoffs this instance.
        /// </summary>
        /// <returns></returns>
        Task Logoff();
    }
}
