using CampusClubManager.Models;

using Microsoft.AspNetCore.Mvc;

namespace CampusClubManager.Controllers
{
    public class ClubController : Controller
    {
        public readonly AppDbContext dbContext;

        public ClubController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(string searchString)
        {
            var result = dbContext.Clubs.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.ClubName.Contains(searchString));
            }

            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = dbContext.Clubs.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Club club)
        {
            var mevcut = dbContext.Clubs.Find(club.ClubId);

            mevcut.ClubName = club.ClubName;
            mevcut.Description = club.Description;

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = dbContext.Clubs.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Club club)
        {
            dbContext.Remove(club);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}