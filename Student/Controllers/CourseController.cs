using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;

namespace Student.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                var CourseData = from CourseTable in EFDbContext.Courses
                                 select CourseTable;
                if (CourseData.Any())
                {
                    //_student = studentData.ToList();
                    //    _student.St_address = studentData.First().St_address;

                    //}
                    //else
                    //{
                    //    return HttpNotFound(); 
                    return View(CourseData.ToList());
                }
            }
            return View();
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Student.Models.Course _Course = new Student.Models.Course();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                var CourseData = from CourseTable in EFDbContext.Courses
                                 where CourseTable.CourseID == id
                                 select CourseTable;
                if (CourseData.Any())
                {
                    _Course.CourseID = CourseData.First().CourseID;
                    _Course.Co_name = CourseData.First().Co_name;
                   

                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_Course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Student.Models.Course _Course = new Student.Models.Course();
            try
            {
                // TODO: Add insert logic here
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Course _info = new Student.Models.Course();
                    TryUpdateModel<Student.Models.Course>(_info, collection);
                    // Student _student = new Student();
                    //_Course.StudentID = _info.StudentID;
                    _Course.Co_name = _info.Co_name;
                    //_parent.Pa_sex = _info.Pa_sex;

                    EFDbContext.Courses.Add(_Course);
                    EFDbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Student.Models.Course _Course = new Student.Models.Course();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var CourseData = from CourseTable in EFDbContext.Courses
                                 where CourseTable.CourseID == id
                                 select CourseTable;
                if (CourseData.Any())
                {
                    _Course.CourseID = CourseData.First().CourseID;
                    _Course.Co_name = CourseData.First().Co_name;
                   
                    return View(_Course);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_Course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Student.Models.Course _Course = new Student.Models.Course();

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

                        Student.Models.Course _info = new Student.Models.Course();
                        TryUpdateModel<Student.Models.Course>(_info, collection);
                        //var studentData = from studenTable in EFDbContext.Students
                        //                  where studenTable.StudentID == id
                        //                  select studenTable;
                        //if (studentData.Any())
                        //{
                        _Course.CourseID = _info.CourseID;
                        //_parent.ParentID = _info.St_address;
                        _Course.Co_name = _info.Co_name;
                       
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

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Student.Models.Course _Course = new Student.Models.Course();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var CourseData = from CourseTable in EFDbContext.Courses
                                 where CourseTable.CourseID == id
                                 select CourseTable;
                if (CourseData.Any())
                {
                    //_student = studentData.First();
                    //EFDbContext.Students.Remove(_student);
                    //EFDbContext.SaveChanges();

                    return View(CourseData);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Student.Models.Course _Course = new Student.Models.Course();
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Course _info = new Student.Models.Course();
                    TryUpdateModel<Student.Models.Course>(_info, collection);

                    //var studentData = from studenTable in EFDbContext.Students
                    //                  where studenTable.StudentID == id
                    //                  select studenTable;
                    //if (studentData.Any())
                    //{
                    _Course = _info;
                    EFDbContext.Courses.Remove(_Course);
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
