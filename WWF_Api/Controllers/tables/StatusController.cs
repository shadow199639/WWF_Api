using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers.tables
{
    [Produces("application/json")]
    [Route("api/Status")]
    public class StatusController : Controller
    {
        private readonly WWFContext _context;

        public StatusController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Status> GetStatus()
        {
            return _context.Status.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetStatus(int id)
        {
            Status status = _context.Status
                .FirstOrDefault(x => x.StatusId == id);
            if (status == null)
                return NotFound();
            return new ObjectResult(status);
        }

        [HttpPost]
        public IActionResult PostStatus([FromBody]Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            _context.Status.Add(status);
            _context.SaveChanges();
            return Ok(status);
        }

        [HttpPut]
        public IActionResult PutStatus([FromBody]Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }
            if (!_context.Status.Any(x => x.StatusId == status.StatusId))
            {
                return NotFound();
            }

            _context.Update(status);
            _context.SaveChanges();
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            Status status = _context.Status
                .FirstOrDefault(x => x.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }
            _context.Status.Remove(status);
            _context.SaveChanges();
            return Ok(status);
        }
    }
}