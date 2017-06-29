using Newtonsoft.Json;
using System;

namespace ServiceLayer
{
    internal class UserSessionModel : IUserSessionModel
    {
        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the session token.
        /// </summary>
        [JsonProperty(PropertyName = "sessionToken")]
        public Guid SessionToken { get; set; }
    }
}
