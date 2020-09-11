using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;

namespace Student.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult Index()
        {
            using (TritonEntities EFDbContext = new TritonEntities())
            {



                var ParentData = from ParentTable in EFDbContext.Parents
                                  select ParentTable;
                if (ParentData.Any())
                {
                    //_student = studentData.ToList();
                    //    _student.St_address = studentData.First().St_address;

                    //}
                    //else
                    //{
                    //    return HttpNotFound(); 
                    return View(ParentData.ToList());
                }
            }
            return View();
        }

        // GET: Parent/Details/5
        public ActionResult Details(int id)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                var ParentData = from ParentTable in EFDbContext.Parents
                                  where ParentTable.ParentID == id
                                  select ParentTable;
                if (ParentData.Any())
                {
                    _parent.ParentID = ParentData.First().ParentID;
                    _parent.Pa_name = ParentData.First().Pa_name;
                    _parent.Pa_sex = ParentData.First().Pa_sex;
                    _parent.StudentID = ParentData.First().StudentID;

                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_parent);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            Dropdownlist _student = new Dropdownlist();
            ViewBag.studentID = _student.DrowStudentID();
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();
            try
            {
                // TODO: Add insert logic here
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Parent _info = new Student.Models.Parent();
                    TryUpdateModel<Student.Models.Parent>(_info, collection);
                    // Student _student = new Student();
                    _parent.StudentID = _info.StudentID;
                    _parent.Pa_name = _info.Pa_name;
                    _parent.Pa_sex = _info.Pa_sex;
                    
                    EFDbContext.Parents.Add(_parent);
                    EFDbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int id)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var ParentData = from ParentTable in EFDbContext.Parents
                                  where ParentTable.ParentID == id
                                  select ParentTable;
                if (ParentData.Any())
                {
                    Dropdownlist _student = new Dropdownlist();
                    ViewBag.studentID = _student.DrowStudentID();
                    _parent.StudentID = ParentData.First().StudentID;
                    _parent.ParentID = ParentData.First().ParentID;
                    _parent.Pa_name = ParentData.First().Pa_name;
                    _parent.Pa_sex = ParentData.First().Pa_sex;
                    //EFDbContext.SaveChanges();
                    return View(_parent);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_parent);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (ModelState.IsValid)
                {
                    using (TritonEntities EFDbContext = new TritonEntities())
                    {

                        Student.Models.Parent _info = new Student.Models.Parent();
                        TryUpdateModel<Student.Models.Parent>(_info, collection);
                        //var studentData = from studenTable in EFDbContext.Students
                        //                  where studenTable.StudentID == id
                        //                  select studenTable;
                        //if (studentData.Any())
                        //{
                        _parent.StudentID = _info.StudentID;
                        //_parent.ParentID = _info.St_address;
                        _parent.Pa_name = _info.Pa_name;
                        _parent.Pa_sex = _info.Pa_sex;
                        EFDbContext.SaveChanges();
                        return RedirectToAction("Index");
                        //}
                        //else
                        //{
                        //    return HttpNotFound();
                        //}
                    }
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int id)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var ParentData = from ParentTable in EFDbContext.Parents
                                  where ParentTable.ParentID == id
                                  select ParentTable;
                if (ParentData.Any())
                {
                    //_student = studentData.First();
                    //EFDbContext.Students.Remove(_student);
                    //EFDbContext.SaveChanges();

                    return View(ParentData);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        // POST: Parent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Student.Models.Parent _parent = new Student.Models.Parent();
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Parent _info = new Student.Models.Parent();
                    TryUpdateModel<Student.Models.Parent>(_info, collection);

                    //var studentData = from studenTable in EFDbContext.Students
                    //                  where studenTable.StudentID == id
                    //                  select studenTable;
                    //if (studentData.Any())
                    //{
                    _parent = _info;
                    EFDbContext.Parents.Remove(_parent);
                    EFDbContext.SaveChanges();

                    return RedirectToAction("Index");
                    //}
                    //else
                    //{
                    //    return HttpNotFound();
                    //}
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
