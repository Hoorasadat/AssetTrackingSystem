using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Repositories
{
    public class APIDepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public APIDepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<IList<Department>> GetAllDepartments()
        {
            return await _httpClient.GetFromJsonAsync<IList<Department>>("getalldepartments");
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"getdepartment/{id}");
        }
    }
}
