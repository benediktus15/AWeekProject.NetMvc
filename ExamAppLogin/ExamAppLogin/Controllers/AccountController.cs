using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamAppLogin.Models;
using ExamAppLogin.Data;

namespace ExamAppLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public AccountController()
        {
            _pagination = new PaginationRepository();
        }
        // GET: Pagination
        private PaginationRepository _pagination = new PaginationRepository();
        public ActionResult Detail(int? id, int? val, int? stat)
        {
            ViewBag.val = val;
            ViewBag.stat = stat;
            ViewBag.so = id;

            if (id == null)
                return HttpNotFound();

            var All = _pagination.getPage((int)id);
            int k = All.no;
            return View(All);
        }

        // Registration
        public ActionResult Register()
        {
            return View();
        }

        // Registration
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " " + " registrasi sukses.";

            }

            return View();
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.Username == user.Username);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("Detail");
                }
                else
                {
                    ModelState.AddModelError("", "Username is wrong");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Results()
        {
            return View();
        }
    }
}