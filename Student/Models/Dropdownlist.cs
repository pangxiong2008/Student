using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;
using System.Net;


namespace Student.Models
{
    public class Dropdownlist
    {
        public List<Student> DrowStudentID()
        {
            List<Student> _list = new List<Student>();
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var StudentData = (from StudentTable in EFDbContext.Students

                                   select StudentTable)
                                 .Distinct();

                if (StudentData.Any())
                {
                    foreach (Student st in StudentData)
                    {
                        _list.Add(st);

                    }


                }
                else
                {

                }

            }
            return _list;

        }
        public List<Course> DrowCourseID()
        {
            List<Course> _list = new List<Course>();
            using (TritonEntities EFDbContext = new TritonEntities())
            {


                var CourseData = (from CourseTable in EFDbContext.Courses

                                   select CourseTable)
                                 .Distinct();

                if (CourseData.Any())
                {
                    foreach (Course st in CourseData)
                    {
                        _list.Add(st);

                    }


                }
                else
                {

                }

            }
            return _list;

        }
    }

}