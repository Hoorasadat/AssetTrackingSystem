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



        // GET api/<DepartmentsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
