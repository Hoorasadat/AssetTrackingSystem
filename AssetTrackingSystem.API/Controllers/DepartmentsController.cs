using AssetTrackingSystem.API.Interfaces;
using AssetTrackingSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }



        // GET: api/<DepartmentsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getalldepartments")]
        public async Task<ActionResult<IList<Department>>> Get()
        {
            try
            {
                return Ok(await _departmentRepository.GetAllDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }



        //GET api/<DepartmentsController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("getdepartment/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Department department = await _departmentRepository.GetDepartmentById(id);

                if (department == null)
                {
                    return NotFound($"Departmen with id = {id} was not found!");
                }

                return Ok(department);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database!");
            }
        }
    }
}
