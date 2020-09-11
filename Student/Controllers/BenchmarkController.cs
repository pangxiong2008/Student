using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;

namespace Student.Controllers
{
    public class BenchmarkController : Controller
    {
        // GET: Benchmark
        public ActionResult Index()
        {
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                var BenchmarkData = from BenchmarkTable in EFDbContext.Benchmarks
                                  select BenchmarkTable;
                if (BenchmarkData.Any())
                {
                    //_student = studentData.ToList();
                    //    _student.St_address = studentData.First().St_address;

                    //}
                    //else
                    //{
                    //    return HttpNotFound(); 
                    return View(BenchmarkData.ToList());
                }
            }
            return View();
        }

        // GET: Benchmark/Details/5
        public ActionResult Details(int id)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                var BenchmarkData = from BenchmarkTable in EFDbContext.Benchmarks
                                    where BenchmarkTable.BenchmarkID == id
                                 select BenchmarkTable;
                if (BenchmarkData.Any())
                {
                    _Benchmark.BenchmarkID = BenchmarkData.First().BenchmarkID;
                    _Benchmark.CourseID = BenchmarkData.First().CourseID;
                    _Benchmark.StudentID = BenchmarkData.First().StudentID;
                    _Benchmark.benchmarkRange = BenchmarkData.First().benchmarkRange;

                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_Benchmark);
        }

        // GET: Benchmark/Create
        public ActionResult Create()
        {
            Dropdownlist _student = new Dropdownlist();
            ViewBag.studentID = _student.DrowStudentID();
            Dropdownlist _Course = new Dropdownlist();
            ViewBag.CourseID = _Course.DrowCourseID();
            return View();
        }

        // POST: Benchmark/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();
            try
            {
                // TODO: Add insert logic here
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Benchmark _info = new Student.Models.Benchmark();
                    TryUpdateModel<Student.Models.Benchmark>(_info, collection);
                    // Student _student = new Student();
                    _Benchmark.StudentID = _info.StudentID;
                    _Benchmark.CourseID = _info.CourseID;
                    _Benchmark.benchmarkRange = _info.benchmarkRange;

                    EFDbContext.Benchmarks.Add(_Benchmark);
                    EFDbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Benchmark/Edit/5
        public ActionResult Edit(int id)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var BenchmarkData = from BenchmarkTable in EFDbContext.Benchmarks
                                 where BenchmarkTable.BenchmarkID == id
                                 select BenchmarkTable;
                if (BenchmarkData.Any())
                {
                    Dropdownlist _student = new Dropdownlist();
                    ViewBag.studentID = _student.DrowStudentID();
                    Dropdownlist _Course = new Dropdownlist();
                    ViewBag.CourseID = _Course.DrowCourseID();
                    _Benchmark.StudentID = BenchmarkData.First().StudentID;
                    _Benchmark.BenchmarkID = BenchmarkData.First().BenchmarkID;
                    _Benchmark.CourseID = BenchmarkData.First().CourseID;
                    _Benchmark.benchmarkRange = BenchmarkData.First().benchmarkRange;
                    //EFDbContext.SaveChanges();
                    return View(_Benchmark);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(_Benchmark);
        }

        // POST: Benchmark/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();

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

                        Student.Models.Benchmark _info = new Student.Models.Benchmark();
                        TryUpdateModel<Student.Models.Benchmark>(_info, collection);
                        //var studentData = from studenTable in EFDbContext.Students
                        //                  where studenTable.StudentID == id
                        //                  select studenTable;
                        //if (studentData.Any())
                        //{
                        _Benchmark.StudentID = _info.StudentID;
                        _Benchmark.BenchmarkID = _info.BenchmarkID;
                        _Benchmark.CourseID = _info.CourseID;
                        _Benchmark.benchmarkRange = _info.benchmarkRange;
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

        // GET: Benchmark/Delete/5
        public ActionResult Delete(int id)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var BenchmarkData = from BenchmarkTable in EFDbContext.Benchmarks
                                 where BenchmarkTable.BenchmarkID == id
                                 select BenchmarkTable;
                if (BenchmarkData.Any())
                {
                    //_student = studentData.First();
                    //EFDbContext.Students.Remove(_student);
                    //EFDbContext.SaveChanges();

                    return View(BenchmarkData);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        // POST: Benchmark/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Student.Models.Benchmark _Benchmark = new Student.Models.Benchmark();
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (TritonEntities EFDbContext = new TritonEntities())
                {
                    Student.Models.Benchmark _info = new Student.Models.Benchmark();
                    TryUpdateModel<Student.Models.Benchmark>(_info, collection);

                    //var studentData = from studenTable in EFDbContext.Students
                    //                  where studenTable.StudentID == id
                    //                  select studenTable;
                    //if (studentData.Any())
                    //{
                    _Benchmark = _info;
                    EFDbContext.Benchmarks.Remove(_Benchmark);
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
