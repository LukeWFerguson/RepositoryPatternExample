using Microsoft.AspNetCore.Mvc;

namespace RepositoryPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeros = new List<SuperHero>() { new SuperHero() { Id = 1, Name = "Spidy" }, new SuperHero() { Id = 2, Name = "Iron" } };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(superHeros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);

            if (hero == null)
            {
                return BadRequest("Super hero not found.");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeros.Add(hero);
            return Ok(superHeros);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = superHeros.Find(x => x.Id == request.Id);

            if (hero == null)
            {
                return BadRequest("Super hero not found.");
            }

            // Making the changes...
            hero.Name = request.Name;

            return Ok(superHeros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = superHeros.Find(x => x.Id == id);

            if (hero == null)
            {
                return BadRequest("Super hero not found.");
            }

            superHeros.Remove(hero);
            return Ok(superHeros);
        }
    }

    public class SuperHero
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
