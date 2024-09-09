using Moq;
using Sprout.Exam.Business;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Interface;
using Sprout.Exam.Test.MockDataObjects;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.Test
{
    public sealed class EmployeeBusinessTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public EmployeeBusinessTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }


        [Fact]
        public void GetAllEmployeeAsync_ShouldReturnListOfEmployees()
        {
            ShouldReturnListOfEmployees().Wait();
        }

        [Fact]
        public void GetEmployeeByIdAsync_ShouldReturnSingleEmployeeById()
        {
            ShouldReturnSingleEmployeeById(1).Wait();
        }

        [Fact]
        public void AddEmployeeAsync_ShouldAddSingleEmployeeOnceAndReturnTrue()
        {
            ShouldAddSingleEmployeeOnceAndReturnTrue().Wait();
        }

        [Fact]
        public void UpdateEmployeeAsync_ShouldUpdateSingleEmployeeOnceAndReturnTrue()
        {
            ShouldUpdateSingleEmployeeOnceAndReturnTrue().Wait();
        }

        [Fact]
        public void DeleteEmployeeAsync_ShouldDeleteSingleEmployeeOnceAndReturnTrue()
        {
            ShouldDeleteSingleEmployeeOnceAndReturnTrue(1).Wait();
        }



        private async Task ShouldReturnListOfEmployees()
        {
            var employeeList = EmployeeMockData.GetTestEmployeeList;

            //Arrange:
            _mockUnitOfWork.Setup(x => x.Employee.GetAllAsync(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                              It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>()))
                                                 .Returns(Task.FromResult(employeeList));

            var employeeBiz = new EmployeeBusiness(_mockUnitOfWork.Object);


            //Act:
            var result = await employeeBiz.GetAllEmployeeAsync();


            //Assert:
            Assert.NotNull(result);
            Assert.True(result.Count() > 1);
        }

        private async Task ShouldReturnSingleEmployeeById(int id)
        {
            var employee = EmployeeMockData.GetTestEmployeeList.FirstOrDefault(x => x.Id == id);

            //Arrange:
            _mockUnitOfWork.Setup(x => x.Employee.GetByIDAsync(It.IsAny<Expression<Func<Employee, bool>>>()))
                                                 .Returns(Task.FromResult(employee));

            var employeeBiz = new EmployeeBusiness(_mockUnitOfWork.Object);


            //Act:
            var result = await employeeBiz.GetEmployeeByIdAsync(id);


            //Assert:
            Assert.NotNull(result);
            Assert.True(employee.Equals(result));
        }

        private async Task ShouldAddSingleEmployeeOnceAndReturnTrue()
        {
            var employee = EmployeeMockData.GetTestEmployeeToAdd;

            //Arrange:
            _mockUnitOfWork.Setup(x => x.Employee.AddAsync(It.IsAny<Employee>()));
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(1));

            var employeeBiz = new EmployeeBusiness(_mockUnitOfWork.Object);


            //Act:
            var result = await employeeBiz.AddEmployeeAsync(employee);


            //Verification:
            _mockUnitOfWork.Verify(x => x.Employee.AddAsync(It.IsAny<Employee>()), Times.Once());


            //Assert:
            Assert.True(result);
        }

        private async Task ShouldUpdateSingleEmployeeOnceAndReturnTrue()
        {
            var newEmployeeInfo = EmployeeMockData.GetTestEmployeeToUpdate;
            var oldEmployeeInfo = EmployeeMockData.GetTestEmployeeList.FirstOrDefault(x => x.Id == newEmployeeInfo.Id);
            string oldFullName = oldEmployeeInfo.FullName;

            //Arrange:
            _mockUnitOfWork.Setup(x => x.Employee.GetByIDAsync(It.IsAny<Expression<Func<Employee, bool>>>()))
                                                 .Returns(Task.FromResult(oldEmployeeInfo));
            _mockUnitOfWork.Setup(x => x.Employee.Update(It.IsAny<Employee>()));
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(1));

            var employeeBiz = new EmployeeBusiness(_mockUnitOfWork.Object);


            //Act:
            var result = await employeeBiz.UpdateEmployeeAsync(newEmployeeInfo);


            //Verification:
            _mockUnitOfWork.Verify(x => x.Employee.Update(It.IsAny<Employee>()), Times.Once());


            //Assert:
            Assert.True(result);
            Assert.NotEqual(oldFullName, newEmployeeInfo.FullName); //Assumes FullName field has been updated:
        }

        private async Task ShouldDeleteSingleEmployeeOnceAndReturnTrue(int id)
        {
            //Arrange:
            _mockUnitOfWork.Setup(x => x.Employee.Delete(id));
            _mockUnitOfWork.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(1));

            var employeeBiz = new EmployeeBusiness(_mockUnitOfWork.Object);


            //Act:
            var result = await employeeBiz.DeleteEmployeeAsync(id);


            //Verification:
            _mockUnitOfWork.Verify(x => x.Employee.Delete(id), Times.Once());


            //Assert:
            Assert.True(result);
        }
    }
}
