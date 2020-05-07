using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class NewsDetails
    {
        public int DnewsId { get; set; }
        public int NewsId { get; set; }
        public string DIng { get; set; }
        public string Head { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual News News { get; set; }
    }
}
