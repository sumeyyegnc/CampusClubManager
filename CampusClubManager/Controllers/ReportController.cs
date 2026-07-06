using CampusClubManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusClubManager.Controllers
{
    public class ReportController : Controller
    {
        public readonly AppDbContext dbContext;

        public ReportController(AppDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult KlupListesi()
        {
            var result = from c in dbContext.Clubs
                         join e in dbContext.Events
            on c.Id equals e.Id;

            return View(result);
        }

   
    }
}
    
