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
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly HrContext _context;

        public SQLDepartmentRepository(HrContext context) 
        {
            _context = context;
        }
        public async Task<IList<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public Task<Department> GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
