using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesLab2.Models;

namespace MoviesLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MoviesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        /// <summary>
        /// Get a list of all movies.
        /// </summary>
        /// <param name="from">Filter movies added from this date time (incusive). Leave empty for no lower limit.</param>
        /// <param name="to">Filter movies added up to this date time (incusive). Leave empty for no upper limit.</param>
        /// <returns>A list of Movie objects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(DateTime? from = null, DateTime? to = null)
        {
            //Return movies by date when were added
            IQueryable<Movie> result = _context.Movies;
            if (from != null && to != null)
                result = result.Where(f => from <= f.DateAdded && f.DateAdded <= to);
            if (from != null)
                result = result.Where(f => from <= f.DateAdded);
            else if (to != null)
                result = result.Where(f => to <= f.DateAdded);

            return await result.Include(e => e.Comments).ToListAsync();
            //return await result.OrderByDescending(m => m.YearOfRelease).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(long id)
        {
            var movie = _context.Movies;

            if (movie == null)
            {
                return NotFound();
            }

            return await movie.Include(e => e.Comments).SingleOrDefaultAsync(e => e.Id == id);

        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
