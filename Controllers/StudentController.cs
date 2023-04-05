using iTextSharp.Models;
using iTextSharp.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTextSharp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Report(Student student)
        {
            StudentReport studentReport = new StudentReport();
            byte[] bytes = studentReport.PrepareReport(GetStudents());
            return File(bytes, "application/pdf");
        }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            Student student = new Student();
            for (int i = 1; i < 6; i++)
            {
                student = new Student();
                student.ID = i;
                student.Name = "Student" + i;
                student.Roll = "Roll" + i;
                student.Department = "Department" + i;
                students.Add(student);
            }
            return students;
        }
    }
}