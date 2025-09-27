using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;

namespace MovieList.Controllers;

public class HomeController : Controller
{
    private MovieContext _context { get; set; }

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var movies = _context.Movies.Include(m=> m.Genre).OrderBy(m => m.Name).ToList();
        return View(movies);
    }

}
