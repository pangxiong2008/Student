using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            //Student.Models.Student _student = new Student.Models.Student();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
               


                var studentData = from studenTable in EFDbContext.Students
                                  select studenTable;
                if (studentData.Any())
                {
                    //_student = studentData.ToList();
                    //    _student.St_address = studentData.First().St_address;

                    //}
                    //else
                    //{
                    //    return HttpNotFound(); 
                    return View(studentData.ToList());
                }
            }
            return View();

          
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
           Student.Models.Student _student = new Student.Models.Student();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

               
              var  studentData = from studenTable in EFDbContext.Students
                           where studenTable.StudentID ==id
                           select studenTable;
                if (studentData.Any())
                {
                    _student.StudentID = studentData.First().StudentID;
                    _student.St_address = studentData.First().St_address;
                    _student.St_birthday = studentData.First().St_birthday;
                    _student.St_name = studentData.First().St_name;

                }
                else
                {
                    return HttpNotFound();
                }
            }
                return View(_student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Student.Models.Student _student = new Student.Models.Student();
            try
            {
                // TODO: Add insert logic here
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Student _info = new Student.Models.Student();
                    TryUpdateModel<Student.Models.Student>(_info, collection);
                   // Student _student = new Student();
                    //_student.StudentID = _info.StudentID;
                    _student.St_address = _info.St_address;
                    _student.St_birthday = _info.St_birthday;
                    _student.St_name = _info.St_name;
                    _student.St_la = _info.St_la;
                    _student.St_long = _info.St_long;
                    EFDbContext.Students.Add(_student);
                    EFDbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            Student.Models.Student _student = new Student.Models.Student();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {
               

                var studentData = from studenTable in EFDbContext.Students
                                  where studenTable.StudentID == id
                                  select studenTable;
                if (studentData.Any())
                {
                    _student.StudentID = studentData.First().StudentID;
                    _student.St_address = studentData.First().St_address;
                    _student.St_birthday = studentData.First().St_birthday;
                    _student.St_name = studentData.First().St_name;
                    //EFDbContext.SaveChanges();
                    return View(_student);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            Student.Models.Student _student = new Student.Models.Student();
                
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

                        Student.Models.Student _info = new Student.Models.Student();
                        TryUpdateModel<Student.Models.Student>(_info, collection);
                        //var studentData = from studenTable in EFDbContext.Students
                        //                  where studenTable.StudentID == id
                        //                  select studenTable;
                        //if (studentData.Any())
                        //{
                            //_student.StudentID = _info.StudentID;
                            _student.St_address = _info.St_address;
                            _student.St_birthday = _info.St_birthday;
                            _student.St_name = _info.St_name;
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student.Models.Student _student = new Student.Models.Student();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {

               
                var studentData = from studenTable in EFDbContext.Students
                                  where studenTable.StudentID == id
                                  select studenTable;
                if (studentData.Any())
                {
                    //_student = studentData.First();
                    //EFDbContext.Students.Remove(_student);
                    //EFDbContext.SaveChanges();

                    return View (_student);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            Student.Models.Student _student = new Student.Models.Student();
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Student _info = new Student.Models.Student();
                    TryUpdateModel<Student.Models.Student>(_info, collection);

                    //var studentData = from studenTable in EFDbContext.Students
                    //                  where studenTable.StudentID == id
                    //                  select studenTable;
                    //if (studentData.Any())
                    //{
                        _student = _info;
                        EFDbContext.Students.Remove(_student);
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
