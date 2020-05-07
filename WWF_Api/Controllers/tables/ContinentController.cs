using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers.tables
{
    [Produces("application/json")]
    [Route("api/Continent")]
    public class ContinentController : Controller
    {
        private readonly WWFContext _context;
        public ContinentController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Continent> GetCon()
        {
            return _context.Continent.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetCon(int id)
        {
            Continent continent = _context.Continent
                .FirstOrDefault(x => x.ConId == id);
            if (continent == null)
                return NotFound();
            return new ObjectResult(continent);
        }

        [HttpPost]
        public IActionResult PostCon([FromBody]Continent continent)
        {
            if (continent == null)
            {
                return BadRequest();
            }

            _context.Continent.Add(continent);
            _context.SaveChanges();
            return Ok(continent);
        }

        [HttpPut]
        public IActionResult PutCon([FromBody]Continent continent)
        {
            if (continent == null)
            {
                return BadRequest();
            }
            if (!_context.Continent.Any(x => x.ConId == continent.ConId))
            {
                return NotFound();
            }

            _context.Update(continent);
            _context.SaveChanges();
            return Ok(continent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCon(int id)
        {
            Continent continent = _context.Continent
                .FirstOrDefault(x => x.ConId == id);
            if (continent == null)
            {
                return NotFound();
            }
            _context.Continent.Remove(continent);
            _context.SaveChanges();
            return Ok(continent);
        }
    }
}