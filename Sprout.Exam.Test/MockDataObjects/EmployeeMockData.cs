using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Sprout.Exam.Test.MockDataObjects
{
    internal sealed class EmployeeMockData
    {
        public static IEnumerable<Employee> GetTestEmployeeList
        {
            get
            {
                return new List<Employee>
                {
                    new Employee
                    {
                        Birthdate = DateTime.Now,
                        FullName = "Jane Doe",
                        Id = 1,
                        Tin = "123215413",
                        EmployeeTypeId = 1
                    },
                    new Employee
                    {
                        Birthdate = DateTime.Now,
                        FullName = "John Doe",
                        Id = 2,
                        Tin = "957125412",
                        EmployeeTypeId = 2
                    }
                };
            }
        }

        public static CreateEmployeeDto GetTestEmployeeToAdd
        {
            get
            {
                return new CreateEmployeeDto
                {
                    FullName = "Add Test Employee",
                    Birthdate = DateTime.Now,
                    Tin = "123456789",
                    TypeId = 1
                };
            }
        }

        public static EditEmployeeDto GetTestEmployeeToUpdate
        {
            get
            {
                return new EditEmployeeDto
                {
                    Id = 1,
                    FullName = "Update Test Employee",
                    Birthdate = DateTime.Now,
                    Tin = "987654321",
                    TypeId = 2
                };
            }
        }
    }
}
