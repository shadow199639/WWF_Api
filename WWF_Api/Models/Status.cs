using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class Status
    {
        public Status()
        {
            Animal = new HashSet<Animal>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
