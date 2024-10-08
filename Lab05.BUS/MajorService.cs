using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class MajorService
    {
        Lab5Entities me = new Lab5Entities();

        public List<Major> GetAllByFaculty(int facultyID)
        {
            return me.Majors.Where(p=>p.FacultyID == facultyID).ToList();

        }
    }
}
