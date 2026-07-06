using CampusClubManager.Models;

using Microsoft.AspNetCore.Mvc;

namespace CampusClubManager.Controllers
{
    public class StudentController : Controller
    {
        public readonly AppDbContext dbContext;

        public StudentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(string searchString)
        {
            var result = dbContext.Students.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.FirstName.Contains(searchString) ||
                                           x.LastName.Contains(searchString));
            }

            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = dbContext.Students.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var mevcut = dbContext.Students.Find(student.StudentId);

            mevcut.FirstName = student.FirstName;
            mevcut.LastName = student.LastName;
            mevcut.Email = student.Email;
            mevcut.Phone = student.Phone;
            mevcut.Department = student.Department;
            mevcut.Password = student.Password;

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = dbContext.Students.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            dbContext.Remove(student);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}