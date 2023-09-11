using AssetTrackingSystem.API.Data;
using AssetTrackingSystem.API.Interfaces;
using AssetTrackingSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.API.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly HrContext _context;

        public SQLEmployeeRepository(HrContext context) 
        {
            _context = context;
        }
        public async Task<IList<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
