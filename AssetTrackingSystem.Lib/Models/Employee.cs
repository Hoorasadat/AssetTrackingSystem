using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
    }
}
