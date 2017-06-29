using System;

namespace ServiceLayer
{
    /// <summary>
    /// User Session.
    /// </summary>
    public interface IUserSessionModel
    {
        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the session token.
        /// </summary>
        Guid SessionToken { get; set; }
    }
}
