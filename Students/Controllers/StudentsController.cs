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
            return View();
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