using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            var students = new List<Student>()
            {
                new Student() {Age=30, FirstName = "Kate", LastName = "Ramsey", Gender = Gender.Female, Id = 1},
                new Student() {Age=23, FirstName = "Zach", LastName = "Ballard", Gender = Gender.Male, Id = 2},
                new Student() {Age=34, FirstName = "Daniel", LastName = "Pollock", Gender = Gender.Male, Id = 3}
            };
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int stuId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            return View();
        }
    }
}