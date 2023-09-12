using AssetTrackingSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.API.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeByEmployeeNumber(string employeeNumber);
    }
}
