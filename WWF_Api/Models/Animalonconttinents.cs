using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class Animalonconttinents
    {
        public int AocId { get; set; }
        public int AnimalId { get; set; }
        public int ConId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Continent Con { get; set; }
    }
}
