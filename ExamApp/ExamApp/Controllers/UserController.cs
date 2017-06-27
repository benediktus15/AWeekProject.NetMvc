using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamApp.Models;

namespace ExamApp.Controllers
{
    public class UserController : Controller
    {
        // Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // Login
        [NonAction]       
        public ActionResult Registration([Bind (Include ="" )] Table user)
        {
            return View(user);
        }
    }
}