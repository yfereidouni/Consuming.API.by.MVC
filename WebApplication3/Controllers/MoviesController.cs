using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public static List<Movie> Movies = new List<Movie> 
        {
            new Movie
            {
                Id=1,
                Title = "ABC",
                Genre="Romance"
            },
            new Movie
            {
                Id=2,
                Title = "Phiphi",
                Genre="Action"
            },
            new Movie
            {
                Id=3,
                Title = "Hitman",
                Genre="Action"
            },
            new Movie
            {
                Id=4,
                Title = "The Pianist",
                Genre="Drama"
            },
        };

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        [HttpPost]
        public void Create(Movie movie)
        {
            Movies.Add(new Movie
            {
                Id = movie.Id,
                Title = movie.Title,  
                Genre = movie.Genre,
            });
        }
    }
}
