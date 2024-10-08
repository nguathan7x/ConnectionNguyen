using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Lab05.DAL.Entities;
namespace Lab05.BUS
{
    public class StudentService
    {
        Lab5Entities me = new Lab5Entities();
        public List<Student> GetAll()
        {
            return me.Students.ToList();

        }

        public List<Student> GetAllHasNoMajor()
        {
            return me.Students.Where(p => p.MajorID == null).ToList();

        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            return me.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();

        }

        public Student FindById(string studentId)
        {
            return me.Students.FirstOrDefault(p => p.StudentID == studentId);
        }

        public void InsertUpdate(Student s)
        {
            me.Students.AddOrUpdate(s);
            me.SaveChanges();
        }

    }
}
