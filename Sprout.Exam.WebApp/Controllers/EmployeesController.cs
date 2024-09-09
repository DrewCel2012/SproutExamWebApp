using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Factory;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Enums;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusiness _employee;

        public EmployeesController(IEmployeeBusiness employee)
        {
            _employee = employee;
        }


        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var result = await Task.FromResult(StaticEmployees.ResultList);
            var result = await _employee.GetAllEmployeeAsync();

            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == id));
            var result = await _employee.GetEmployeeByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            //var item = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == input.Id));
            //if (item == null) return NotFound();
            //item.FullName = input.FullName;
            //item.Tin = input.Tin;
            //item.Birthdate = input.Birthdate.ToString("yyyy-MM-dd");
            //item.TypeId = input.TypeId;

            bool result = await _employee.UpdateEmployeeAsync(input);

            if (!result)
                return BadRequest();

            return Ok();
            //return Ok(item);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            //var id = await Task.FromResult(StaticEmployees.ResultList.Max(m => m.Id) + 1);
            //StaticEmployees.ResultList.Add(new EmployeeDto
            //{
            //    Birthdate = input.Birthdate.ToString("yyyy-MM-dd"),
            //    FullName = input.FullName,
            //    Id = id,
            //    Tin = input.Tin,
            //    TypeId = input.TypeId
            //});
            
            bool result = await _employee.AddEmployeeAsync(input);

            if (!result)
                return BadRequest();

            int id = _employee.GetId;
            return Created($"/api/employees/{id}", id);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = await Task.FromResult(StaticEmployees.ResultList.FirstOrDefault(m => m.Id == id));
            //if (result == null) return NotFound();
            //StaticEmployees.ResultList.RemoveAll(m => m.Id == id);

            bool result = await _employee.DeleteEmployeeAsync(id);

            if (!result)
                return BadRequest();

            return Ok();
            //return Ok(id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/{absentDays}/{workedDays}/calculate")]
        public async Task<IActionResult> Calculate(int id, double absentDays, double workedDays)
        {
            var result = await _employee.GetEmployeeByIdAsync(id);

            if (result == null) return NotFound();

            var type = (EmployeeType)result.EmployeeTypeId;

            INetIncome netIncome = NetIncomeFactory.GetNetIncomeType(type);
            double input = type.Equals(EmployeeType.Regular) ? absentDays : workedDays;
            double finalComputation = netIncome.Compute(input);
            
            return Ok(new { result = finalComputation.ToString("N2") });
        }
    }
}
