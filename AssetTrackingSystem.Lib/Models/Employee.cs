using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string EmployeeNumber { get; set; }

        [MaxLength(10)]
        public string Firstname { get; set; }

        [MaxLength(10)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Position { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        public int DepartmentID { get; set; }
    }
}
