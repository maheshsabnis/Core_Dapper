using Core_Dapper.Models;
using Core_Dapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceRepository<Department, int> deptRepo;
        public DepartmentController(IServiceRepository<Department, int> deptRepo)
        {
            this.deptRepo = deptRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await deptRepo.GetAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await deptRepo.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Department department)
        {
            try
            {
                var result = await deptRepo.CreateAsync(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,Department department)
        {
            try
            {
                var result = await deptRepo.UpdateAsync(id,department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await deptRepo.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
