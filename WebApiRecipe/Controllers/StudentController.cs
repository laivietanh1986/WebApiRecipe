using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiRecipe.Models;

namespace WebApiRecipe.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Request.IsAjaxRequest();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                return View(student);
            }
            return new HttpNotFoundResult("Not Found");
            
        }
    }
}