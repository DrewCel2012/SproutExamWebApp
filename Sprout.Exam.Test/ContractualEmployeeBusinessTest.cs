using Sprout.Exam.Business;
using Sprout.Exam.Business.Interface;
using System;
using Xunit;

namespace Sprout.Exam.Test
{
    public sealed class ContractualEmployeeBusinessTest
    {
        [Theory]
        [InlineData(15.5, 7750.00)]
        public void Compute_ShouldCalculateNetIncomeOfContractualEmployee(double input, double actual)
        {
            // Arrange:
            INetIncome netIncome = new ContractualEmployeeBusiness();

            // Act:
            double result = netIncome.Compute(input);

            // Assert:
            Assert.Equal(Math.Round(result, 2), actual);
        }
    }
}
