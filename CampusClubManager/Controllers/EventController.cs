
using CampusClubManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CampusClubManager.Controllers
{
    public class EventController : Controller
    {
        public readonly AppDbContext dbContext;

        public EventController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(string searchString)
        {
            var result = dbContext.Events.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.EventName.Contains(searchString));
            }

            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") != "true")
             return RedirectToAction("Login", "Admin");
            ViewBag.Clubs = dbContext.Clubs.ToList(); // dropdown için
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event events)
        {
            dbContext.Events.Add(events);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Clubs = dbContext.Clubs.ToList();

            var result = dbContext.Events.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Event events)
        {
            var mevcut = dbContext.Events.Find(events.EventId);

            mevcut.EventName = events.EventName;
            mevcut.EventDate = events.EventDate;
            mevcut.Location = events.Location;
            mevcut.ClubId = events.ClubId;

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = dbContext.Events.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Event events)
        {
            dbContext.Remove(events);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}