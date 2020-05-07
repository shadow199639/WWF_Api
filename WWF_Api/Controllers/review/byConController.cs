using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWF_Api.Models;

namespace WWF_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/byCon")]
    public class byConController : Controller
    {
        private readonly WWFContext _context;

        public byConController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet("{cname}")]
        public async Task<IActionResult> getByStatus(string cname)
        {
            var res = (from a in _context.Animal
                       join aoc in _context.Animalonconttinents on a.AnimalId equals aoc.AnimalId
                       join con in _context.Continent on aoc.ConId equals con.ConId
                       where con.ConName == cname
                       select new byContinentDTO()
                       {
                           AnimalId = a.AnimalId,
                           AnimalName = a.AnimalName,
                           ConName = con.ConName
                       }).OrderBy(c => c.AnimalName);

            return Ok(res);
        }
    }
}