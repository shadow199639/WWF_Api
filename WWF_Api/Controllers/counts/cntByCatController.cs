using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWF_Api.Models;


namespace WWF_Api.Controllers.counts
{
    [Produces("application/json")]
    [Route("api/cntByCat")]
    public class cntByCatController : Controller
    {
        private readonly WWFContext _context;

        public cntByCatController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = (from c in _context.Category
                       join a in _context.Animal on c.CatId equals a.CatId
                       group c by new { c.CatId, c.CatName } into cRes
                       select new cntByCatDTO()
                       {
                           CatId = cRes.Key.CatId,
                           CatName = cRes.Key.CatName,
                           Count = cRes.Count()
                       }).OrderBy(c => c.CatName);

            return Ok(res);
        }
    }
}
