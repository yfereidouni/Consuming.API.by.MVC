using Movies.MVC.Models;

namespace Movies.MVC.Services;

public interface IMoviesServices
{
    IEnumerable<Movie> GetMovies();
}
