using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWF_Api.Models;


namespace WWF_Api.Controllers.review
{
    [Produces("application/json")]
    [Route("api/cntByCon")]

    public class cntByConController : Controller
    {
        private readonly WWFContext _context;

        public cntByConController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = (from c in _context.Continent
                       from a in _context.Animal
                       join aoc in _context.Animalonconttinents on a.AnimalId equals aoc.AnimalId
                       where aoc.ConId == c.ConId
                       group c by new { c.ConName, c.ConId } into cRes
                       select new cntByConDTO()
                       {
                           ConId = cRes.Key.ConId,
                           ConName = cRes.Key.ConName,
                           Count = cRes.Count()
                       }).OrderBy(c => c.ConName);

            return Ok(res);
        }

    }
}
