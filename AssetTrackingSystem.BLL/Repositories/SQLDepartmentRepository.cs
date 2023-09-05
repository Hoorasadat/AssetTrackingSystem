using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Repositories
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        public Task<IList<Department>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
