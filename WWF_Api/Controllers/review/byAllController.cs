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
    [Route("api/byAll")]
    public class byAllController : Controller
    {
        private readonly WWFContext _context;
        public byAllController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimal()
        {
            var res = (from a in _context.Animal
                       select new byAllDTO()
                       {
                           AnimalId = a.AnimalId,
                           AnimalName = a.AnimalName
                       }).OrderBy(c => c.AnimalId).ToList();

            return Ok(res);
        }
    }
}