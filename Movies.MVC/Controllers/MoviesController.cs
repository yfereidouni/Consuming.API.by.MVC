using Microsoft.AspNetCore.Mvc;
using Movies.MVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace Movies.MVC.Controllers;

public class MoviesController : Controller
{
    public MoviesController()
    {

    }

    public async Task<IActionResult> Index()
    {
        var apiClient = new HttpClient();

        var response = await apiClient.GetAsync("https://localhost:5000/api/movies/");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(content);

        return View(movieList);
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View(new Movie { Id = 9 });
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie model)
    {
        var apiClient = new HttpClient();
        //var stringContent = new StringContent(myMovie.ToString());
        //var response = await apiClient.PostAsync("https://localhost:5000/api/movies/", stringContent);

        var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await apiClient.PostAsync("https://localhost:5000/api/movies/", stringContent);

        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }


}