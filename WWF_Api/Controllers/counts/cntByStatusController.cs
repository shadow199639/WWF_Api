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
    [Route("api/cntByStatus")]
    public class cntByStatusController : Controller
    {
        private readonly WWFContext _context;

        public cntByStatusController(WWFContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            var res = (from s in _context.Status
                       join a in _context.Animal on s.StatusId equals a.StatusId
                       group s by new { s.StatusId, s.StatusName } into sRes
                       select new cntByStatusDTO()
                       {
                           StatusId = sRes.Key.StatusId,
                           StatusName = sRes.Key.StatusName,
                           Count = sRes.Count()
                       }).OrderBy(s => s.StatusId);

            return Ok(res);
        }
    }
}