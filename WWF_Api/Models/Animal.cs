using System;
using System.Collections.Generic;

namespace WWF_Api
{
    public partial class Animal
    {
        public Animal()
        {
            Animalonconttinents = new HashSet<Animalonconttinents>();
        }

        public int AnimalId { get; set; }
        public int CatId { get; set; }
        public int StatusId { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public int? Population { get; set; }
        public string Place { get; set; }
        public string Img { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Animalonconttinents> Animalonconttinents { get; set; }
    }
}
