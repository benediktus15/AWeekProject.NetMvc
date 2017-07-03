using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam.Models;

namespace Exam.Controllers
{
    public class PaginationController : Controller
    {
        private ListRevo _List = null;
        private ListKumpul _List1 = null;
        public PaginationController()
        {
            _List = new ListRevo();
            _List1 = new ListKumpul();
            _pagination = new PaginationRepository();
        }
        // GET: Pagination
        private PaginationRepository _pagination = new PaginationRepository();
        public ActionResult Detail(int? id, int? val, int? stat)
        {
            ViewBag.val = val;
            ViewBag.stat = stat;
            ViewBag.so = id;
            List<Teams> team = _List.GetTeam();
            List<Kumpuls> kumpul = _List.GetTeam1();
            var du = _pagination.getAll();
            var c = (from n in du select n).Count() + 1;
            if (stat == c)
            {
                /*foreach (var item in team.Where(cas => cas.Nilai == 0))
                foreach (var item in team.Where(cas => cas.Nilai == 0))
                {
                    item.Nilai = (int)val;
                }*/
                var mu = "";
                var tes = from i in team select i;
                foreach (var ha in tes)
                {
                    mu = ha.Name;
                }

                _List1.AddEntry(new Kumpuls { Name = mu, Nilai = (int)val });
                return RedirectToAction("Index");
            }


            var a = from ka in team where ka.Name == "Hanafi" select ka.Name;
            foreach (var op in a)
            {
                op.ToString();
            }

            if (id == null)
                return HttpNotFound();

            var All = _pagination.getPage((int)id);
            int k = All.no;
            return View(All);
        }

        public ActionResult Tmp()
        {
            var Alc = _pagination.getAll();
            return View(Alc);
        }

        public ActionResult Hasil()
        {
            List<Kumpuls> kumpul = _List.GetTeam1();
            return View(kumpul);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Teams team)
        {
            _List.AddEntry(team);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {

            Teams team = _List.GetTeam(0);
            return View(team);
        }
        [HttpPost]
        public ActionResult Index(Teams team)
        {
            _List.UpdateEntry(team);
            return RedirectToAction("Next");
            //return RedirectToAction(HttpUtility.UrlEncode());
        }

        public ActionResult EditContent(int? id)
        {
            Models.Pagination page = _pagination.getPage((int)id);
            int gjaja = page.no;
            return View(page);
        }

        [HttpPost]
        public ActionResult EditContent(Models.Pagination page)
        {

            int jhd = page.no;
            _pagination.UpdateEntry1(page);
            return RedirectToAction("Tmp");
        }

        public ActionResult Delete(int? id)
        {
            Models.Pagination page = _pagination.getDel((int)id);
            int gjaja = page.no;
            return View(page);
        }

        [HttpPost]
        public ActionResult Delete(Models.Pagination page)
        {
            _pagination.DeleteEntry(page);
            return RedirectToAction("Tmp");
        }

        public ActionResult Add1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add1(Models.Pagination page)
        {
            _pagination.AddEntry1(page);
            return RedirectToAction("Tmp");
        }

        public ActionResult Next()
        {
            return View();
        }

    }
}