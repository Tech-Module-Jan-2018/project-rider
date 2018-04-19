namespace IMDB.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class FilmController : Controller
    {
        private readonly IMDBDbContext db;

        public FilmController(IMDBDbContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var films = this.db.Films.ToList();

            return View(films);
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                this.db.Films.Add(film);

                this.db.SaveChanges();
                return Redirect("/");
            }
            return View();
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult Edit(int? id)
        {
            var film = this.db.Films.Find(id);

            return View(film);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                this.db.Films.Update(film);
                this.db.SaveChanges();

                return Redirect("/");
            }

            return View(film);

        }

        [HttpGet]
        [Route("/delete/{id}")]
        public IActionResult Delete(int? id)
        {
            var film = this.db.Films.Find(id);

            return View(film);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult Delete(Film film)
        {
            this.db.Films.Remove(film);
            this.db.SaveChanges();
            return Redirect("/");
        }
    }
}
