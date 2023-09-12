using AssetTrackingSystem.API.Interfaces;
using AssetTrackingSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



        // GET: api/<EmployeesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getallemployees")]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                return Ok(await _employeeRepository.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }



        // GET api/<EmployeesController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getemployee/{employeeNumber}")]
        public async Task<ActionResult> GetEmployeeByEmployeeNumber(string employeeNumber)
        {
            try
            {
                Employee employee = await _employeeRepository.GetEmployeeByEmployeeNumber(employeeNumber);

                if (employee == null)
                {
                    return NotFound($"Employee with Employee Number = {employeeNumber} was not found!");
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }
    }
}
