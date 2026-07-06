using CampusClubManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusClubManager.Controllers
{
    public class RaporController : Controller
    {
        public readonly AppDbContext dbContext;

        public RaporController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(string clubName)
        {
            var query = dbContext.Events
                .Include(x => x.Club)
                .AsQueryable();

            if (!string.IsNullOrEmpty(clubName))
            {
                query = query.Where(x => x.Club != null && x.Club.ClubName == clubName);
            }

            var result = query.ToList();

            return View(result);
        }
    }
}