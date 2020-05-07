using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWF_Api.Models
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }
        public string CatName { get; set; }
        public string StatusName { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public int? Population { get; set; }
        public string Place { get; set; }
        public string Img { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class byAllDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class byStatusDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string StatusName { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class byContinentDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string ConName { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class byCategoryDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string CatName { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class cntByConDTO
    {
        public int ConId { get; set; }
        public string ConName { get; set; }
        public int Count { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class cntByCatDTO
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public int Count { get; set; }
    }
}

namespace WWF_Api.Models
{
    public class cntByStatusDTO
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int Count { get; set; }
    }
}