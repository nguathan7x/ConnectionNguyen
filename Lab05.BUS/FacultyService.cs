using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.BUS
{
    public class FacultyService
    {
        Lab5Entities me = new Lab5Entities();
        public List<Faculty> GetAll()
        {
            return me.Faculties.ToList();

        }
    }
}
