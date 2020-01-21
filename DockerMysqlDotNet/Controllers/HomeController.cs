using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerMysqlDotNet.Models;

namespace DockerMysqlDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context db;
        public HomeController(Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult AddStudent(Models.Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
