using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers.tables
{
    [Produces("application/json")]
    [Route("api/NewsDetails")]
    public class NewsDetailsController : Controller
    {
        private readonly WWFContext _context;
        public NewsDetailsController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<NewsDetails> GetNewsDetails()
        {
            return _context.NewsDetails.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetNewsDetails(int id)
        {
            NewsDetails news = _context.NewsDetails
                .FirstOrDefault(x => x.DnewsId == id);
            if (news == null)
                return NotFound();
            return new ObjectResult(news);
        }

        [HttpPost]
        public IActionResult PostDNEWS([FromBody]NewsDetails dnews)
        {
            if (dnews == null)
            {
                return BadRequest();
            }

            _context.NewsDetails.Add(dnews);
            _context.SaveChanges();
            return Ok(dnews);
        }

        [HttpPut]
        public IActionResult PutDNEWS([FromBody]NewsDetails dnews)
        {
            if (dnews == null)
            {
                return BadRequest();
            }
            if (!_context.NewsDetails.Any(x => x.DnewsId == dnews.DnewsId))
            {
                return NotFound();
            }

            _context.Update(dnews);
            _context.SaveChanges();
            return Ok(dnews);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDNEWS(int id)
        {
            NewsDetails dnews = _context.NewsDetails
                .FirstOrDefault(x => x.DnewsId == id);
            if (dnews == null)
            {
                return NotFound();
            }
            _context.NewsDetails.Remove(dnews);
            _context.SaveChanges();
            return Ok(dnews);
        }
    }
}