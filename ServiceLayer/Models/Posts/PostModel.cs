using Newtonsoft.Json;
using System;

namespace ServiceLayer
{
    internal class PostModel : IPostModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public long DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        [JsonProperty(PropertyName = "commentsCount")]
        public int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [any new comments].
        /// </summary>
        [JsonProperty(PropertyName = "anyNewComments")]
        public bool AnyNewComments { get; set; }

        /// <summary>
        /// Gets or sets you tube link.
        /// </summary>
        [JsonProperty(PropertyName = "youTubeLink")]
        public string YouTubeLink { get; set; }

        public Uri Image
        {
            get
            {
                return new Uri($"{Constants.WebsiteBaseAddress}{ImageUrl}");
            }
        }

        public string ImageHtml
        {
            get
            {
                return $"<body style='background-color: transparent; margin: 0; padding 0;'><img style='width: 100%; margin: 0px;' src='{Constants.WebsiteBaseAddress}{ImageUrl}' /></body>";
            }
        }
    }
}
