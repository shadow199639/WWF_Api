using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class Category
    {
        public Category()
        {
            Animal = new HashSet<Animal>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
