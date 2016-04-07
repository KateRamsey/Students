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
            if (Session["students"] == null)
            {
                var students = new List<Student>()
                 {
                new Student() {Age = 30, FirstName = "Kate", LastName = "Ramsey", Gender = "Female", Id = 1},
                new Student() {Age = 23, FirstName = "Zach", LastName = "Ballard", Gender = "Male", Id = 2},
                new Student() {Age = 34, FirstName = "Daniel", LastName = "Pollock", Gender = "Male", Id = 3}
                  };
                Session["students"] = students;
            }


            return View(Session["students"]);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newStudent);
            }

            if (Session["students"] == null)
            {
                newStudent.Id = 1;
                var s = new List<Student> {newStudent};
                Session["students"] = s;
            }
            else
            {
                List<Student> sessionStudents = (List<Student>)Session["students"];
                newStudent.Id = sessionStudents.Max(t => t.Id) + 1;
                sessionStudents.Add(newStudent);
                Session["students"] = sessionStudents;
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("students/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            List<Student> sessionStudents = (List<Student>)Session["students"];
            if (sessionStudents == null)
            {
                return RedirectToAction("Create");
            }
            foreach (var s in sessionStudents.Where(s => s.Id == Id))
            {
                return View(s);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            List<Student> sessionStudents = (List<Student>)Session["students"];
            if (sessionStudents == null)
            {
                return RedirectToAction("Create");
            }
            foreach (var s in sessionStudents.Where(s => s.Id == editStudent.Id))
            {
                s.Age = editStudent.Age;
                s.FirstName = editStudent.FirstName;
                s.LastName = editStudent.LastName;
                s.Gender = editStudent.Gender;
            }

            Session["students"] = sessionStudents;

            return RedirectToAction("Index");
        }
    }
}