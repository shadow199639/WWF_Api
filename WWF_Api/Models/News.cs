using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class News
    {
        public News()
        {
            NewsDetails = new HashSet<NewsDetails>();
        }

        public int NewsId { get; set; }
        public string Img { get; set; }
        public string Head { get; set; }
        public string PublishedD { get; set; }
        public string PublishedT { get; set; }

        public virtual ICollection<NewsDetails> NewsDetails { get; set; }
    }
}
