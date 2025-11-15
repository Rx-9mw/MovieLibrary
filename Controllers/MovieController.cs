using Microsoft.AspNetCore.Mvc;
using AplikacjaMVC.Models;

namespace AplikacjaMVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(string? view, int? id)
        {
            switch (view)
            {
                case "list":
                    var movies = MovieRepository.GetAll();
                    return View("List", movies);

                case "add":
                    ViewBag.Action = "Add";
                    return View("AddEditMovie", new Movie());

                case "edit":
                    if (id == null){ 
                        return Content("brak takiego id");
                    }
                    var movie = MovieRepository.GetById(id.Value);
                    ViewBag.Action = "Edit";
                    return View("AddEditMovie", movie);

                default:
                    return Redirect("/?view=list");
            }
        }
        
        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (!ModelState.IsValid){
                ViewBag.Action = "Add";
                return View("AddEditMovie", movie);
            }

            MovieRepository.Add(movie);

            return Redirect("/?view=list");
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid){
                ViewBag.Action = "Edit";
                return View("AddEditMovie", movie);
            }

            MovieRepository.Update(movie);

            return Redirect("/?view=list");
        }

        public IActionResult Delete(int id)
        {
            MovieRepository.Delete(id);
            return Redirect("/?view=list");
        }



    }
}
