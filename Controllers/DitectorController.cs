using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationPloomes.Interfaces;
using WebApplicationPloomes.Models;
using WebApplicationPloomes.Repositories;


namespace WebApplicationPloomes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _repository;

        public DirectorController(IDirectorRepository directorRepository) {
            _repository = directorRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors() {
            IEnumerable<Director> directorlist = await _repository.Selectall();
            if (directorlist.Any()) {
                return Ok(directorlist);
            }
            return BadRequest("Database is empty");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDirector(int id)
        {
            Director director = await _repository.SelectById(id);

            if (director == null)
            {
                return NotFound("Id is not present in the database");
            }

            return Ok(director);

        }

        [HttpPost]
        public async Task<ActionResult> NewDirector(Director director)
        {
            _repository.Create(director);
            if (await _repository.SaveAsync()) {
                return Ok("Director has been added to the database");
            }

            return BadRequest("Oops, something went wrong");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDirector(Director director)
        {
            _repository.Update(director);
            if (await _repository.SaveAsync())
            {
                return Ok("Director info has been updated in the database");
            }

            return BadRequest("Oops, something went wrong");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            Director director = await _repository.SelectById(id);

            if (director == null)
            {
                return NotFound("Id is already not present in the database");
            }
            _repository.Delete(director);
            if (await _repository.SaveAsync())
            {
                return Ok("Director has been deleted from the database");
            }

            return BadRequest("Oops, something went wrong");
        }
    }
}
