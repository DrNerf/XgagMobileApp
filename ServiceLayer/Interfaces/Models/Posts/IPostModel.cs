using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IPostModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        long DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [any new comments].
        /// </summary>
        bool AnyNewComments { get; set; }

        /// <summary>
        /// Gets or sets you tube link.
        /// </summary>
        string YouTubeLink { get; set; }

        Uri Image { get; }

        string ImageHtml { get; }
    }
}
