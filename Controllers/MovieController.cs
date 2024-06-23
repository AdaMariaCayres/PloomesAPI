using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApplicationPloomes.Interfaces;
using WebApplicationPloomes.Models;
using WebApplicationPloomes.Repositories;


namespace WebApplicationPloomes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMovieRepository repository;

        public MovieController(IMovieRepository movieRepository, AppDbContext dbContext)
        {
            this.repository = movieRepository;
            _context = dbContext;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() {
            IEnumerable<Movie> movielist = await this.repository.Selectall();
            if (movielist.Any()) {
                return Ok(movielist);
            }
            return BadRequest("Database is empty");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            Movie movie = await this.repository.SelectById(id);

            if (movie == null)
            {
                return NotFound("Id is not present in the database");
            }

            return Ok(movie);

        }
            
        [HttpPost]
        public async Task<ActionResult> NewMovie(Movie movie)
        {

            var director = await _context.Directors.FindAsync(movie.DirectorId);
            if (director == null)
            {
                return BadRequest("Invalid Director Id");
            }

            _context.Movies.Add(movie);
            await this.repository.SaveAsync();

            return Ok("Movie has been added to the database");
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            Movie movie = await this.repository.SelectById(id);

            if (movie == null)
            {
                return NotFound("Id is already not present in the database");
            }
            this.repository.Delete(movie);
            if (await this.repository.SaveAsync())
            {
                return Ok("Movie has been deleted from the database");
            }

            return BadRequest("Oops, something went wrong");
        }
    }
}
