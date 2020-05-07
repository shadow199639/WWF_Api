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
    [Route("api/AnimalDetails")]
    public class AnimalDetailsController : Controller
    {
        private readonly WWFContext _context;

        public AnimalDetailsController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AnimalDTO> GetAnimals()
        {
            var animals = (from temp in _context.Animal
                          select new AnimalDTO()
                          {
                              AnimalId = temp.AnimalId,
                              CatName = temp.Cat.CatName,
                              StatusName = temp.Status.StatusName,
                              AnimalName = temp.AnimalName,
                              Description = temp.Description,
                              Habitat = temp.Habitat,
                              Population = temp.Population,
                              Place = temp.Place,
                              Img = temp.Img
                        }).OrderBy(t => t.AnimalName);

            return animals;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimals(long id)
        {
            var animal = await _context.Animal.Select(temp => new AnimalDTO()
            {
                AnimalId = temp.AnimalId,
                CatName = temp.Cat.CatName,
                StatusName = temp.Status.StatusName,
                AnimalName = temp.AnimalName,
                Description = temp.Description,
                Habitat = temp.Habitat,
                Population = temp.Population,
                Place = temp.Place,
                Img = temp.Img
            }).SingleOrDefaultAsync(b => b.AnimalId == id);

            if (animal == null)
                return NotFound();
            return Ok(animal);
        }
    }
}