using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers.tables
{
    [Produces("application/json")]
    [Route("api/News")]
    public class NewsController : Controller
    {
        private readonly WWFContext _context;
        public NewsController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<News> GetNews()
        {
            return _context.News.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetNews(int id)
        {
            News news = _context.News
                .FirstOrDefault(x => x.NewsId == id);
            if (news == null)
                return NotFound();
            return new ObjectResult(news);
        }

        [HttpPost]
        public IActionResult PostNews([FromBody]News news)
        {
            if (news == null)
            {
                return BadRequest();
            }

            _context.News.Add(news);
            _context.SaveChanges();
            return Ok(news);
        }

        [HttpPut]
        public IActionResult PutNews([FromBody]News news)
        {
            if (news == null)
            {
                return BadRequest();
            }
            if (!_context.News.Any(x => x.NewsId == news.NewsId))
            {
                return NotFound();
            }

            _context.Update(news);
            _context.SaveChanges();
            return Ok(news);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            News news = _context.News
                .FirstOrDefault(x => x.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }
            _context.News.Remove(news);
            _context.SaveChanges();
            return Ok(news);
        }
    }
}