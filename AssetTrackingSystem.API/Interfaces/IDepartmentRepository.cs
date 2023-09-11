using AssetTrackingSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.API.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IList<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}
