using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business
{
    public sealed class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            using (_unitOfWork)
            {
                IEnumerable<Employee> employees = await _unitOfWork.Employee.GetAllAsync(filter: f => f.IsDeleted == false, orderBy: o => o.OrderBy(x => x.FullName));

                return employees;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            using (_unitOfWork)
            {
                Employee employee = await _unitOfWork.Employee.GetByIDAsync(filter: f => f.Id == id);

                return employee;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            int result = 0;

            using (_unitOfWork)
            {
                _unitOfWork.Employee.Delete(id);
                result = await _unitOfWork.SaveChangesAsync();
            }

            return (result > 0);
        }

        public async Task<bool> UpdateEmployeeAsync(EditEmployeeDto dto)
        {
            int result = 0;

            using (_unitOfWork)
            {
                Employee employee = await _unitOfWork.Employee.GetByIDAsync(filter: f => f.Id == dto.Id);

                employee.FullName = dto.FullName;
                employee.Birthdate = dto.Birthdate;
                employee.Tin = dto.Tin;
                employee.EmployeeTypeId = dto.TypeId;

                using (_unitOfWork)
                {
                    _unitOfWork.Employee.Update(employee);
                    result = await _unitOfWork.SaveChangesAsync();
                }

                return (result > 0);
            }
        }

        public async Task<bool> AddEmployeeAsync(CreateEmployeeDto dto)
        {
            int result = 0;
            var employee = new Employee
            {
                FullName = dto.FullName,
                Birthdate = Convert.ToDateTime(dto.Birthdate),
                Tin = dto.Tin,
                EmployeeTypeId = dto.TypeId
            };

            using (_unitOfWork)
            {
                await _unitOfWork.Employee.AddAsync(employee);
                result = await _unitOfWork.SaveChangesAsync();
            }

            GetId = employee.Id;

            return (result > 0);
        }


        public int GetId { get; set; }
    }
}
