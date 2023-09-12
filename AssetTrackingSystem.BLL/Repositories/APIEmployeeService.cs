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
    public class APIEmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public APIEmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<IList<Employee>> GetAllEmployees()
        {
            return await _httpClient.GetFromJsonAsync<IList<Employee>>("getallemployees");
        }



        public async Task<Employee> GetEmployeeByEmployeeNumber(string employeeNumber)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"getemployee/{employeeNumber}");
        }
    }
}
