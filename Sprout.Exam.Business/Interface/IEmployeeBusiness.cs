using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interface
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateEmployeeAsync(EditEmployeeDto dto);
        Task<bool> AddEmployeeAsync(CreateEmployeeDto dto);

        int GetId { get; set; }
    }
}
