using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IList<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
    }
}
