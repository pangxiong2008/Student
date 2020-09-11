using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;

namespace Student.Controllers
{
    public class GoogleController : Controller
    {
        // GET: Google
        public ActionResult Index()
        {
            return View();
        }

        // GET: Google/Details/5
        public ActionResult Details(int id)
        {
            Student.Models.Student _student = new Student.Models.Student();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                var studentData = from studenTable in EFDbContext.Students
                                  where studenTable.StudentID == id
                                  select studenTable;
                if (studentData.Any())
                {
                   ViewBag.la = studentData.First().St_la;
                    ViewBag.lo = studentData.First().St_long;
                   
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        // GET: Google/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Google/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Google/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Google/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Google/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Google/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
