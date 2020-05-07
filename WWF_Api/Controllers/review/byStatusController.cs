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
    [Route("api/byStatus")]
    public class byStatusController : Controller
    {
        private readonly WWFContext _context;

        public byStatusController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet("{sname}")]
        public async Task<IActionResult> getByStatus(string sname)
        {
            var animal = _context.Animal.Include(b => b.Status).Select(b =>
        new byStatusDTO()
        {
            AnimalId = b.AnimalId,
            AnimalName = b.AnimalName,
            StatusName = b.Status.StatusName
        }).Where(predicate: b => b.StatusName.CompareTo(sname) == 0).OrderBy(c => c.AnimalName);

            return Ok(animal);
        }
    }
}