using Sprout.Exam.Business;
using Sprout.Exam.Business.Interface;
using System;
using Xunit;

namespace Sprout.Exam.Test
{
    public sealed class RegularEmployeeBusinessTest
    {
        [Theory]
        [InlineData(1, 16690.91)]
        public void Compute_ShouldCalculateNetIncomeOfRegularEmployee(double input, double actual)
        {
            // Arrange:
            INetIncome netIncome = new RegularEmployeeBusiness();

            // Act:
            double result = netIncome.Compute(input);

            // Assert:
            Assert.Equal(Math.Round(result, 2), actual);
        }
    }
}
