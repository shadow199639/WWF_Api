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
    [Route("api/byCategory")]
    public class byCategoryController : Controller
    {
        private readonly WWFContext _context;

        public byCategoryController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet("{cname}")]
        public async Task<IActionResult> getByStatus(string cname)
        {
            var animal = _context.Animal.Include(b => b.Cat).Select(b =>
        new byCategoryDTO()
        {
            AnimalId = b.AnimalId,
            AnimalName = b.AnimalName,
            CatName = b.Cat.CatName
        }).Where(predicate: b => b.CatName.CompareTo(cname) == 0).OrderBy(b => b.AnimalName);

            return Ok(animal);
        }
    }
}
