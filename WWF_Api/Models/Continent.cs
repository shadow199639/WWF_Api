using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class Continent
    {
        public Continent()
        {
            Animalonconttinents = new HashSet<Animalonconttinents>();
        }

        public int ConId { get; set; }
        public string ConName { get; set; }

        public virtual ICollection<Animalonconttinents> Animalonconttinents { get; set; }
    }
}
