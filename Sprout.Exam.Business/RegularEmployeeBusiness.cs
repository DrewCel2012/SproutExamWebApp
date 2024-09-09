using Microsoft.Extensions.Configuration;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Helpers;

namespace Sprout.Exam.Business
{
    public sealed class RegularEmployeeBusiness : INetIncome
    {
        private readonly IConfiguration _configuration;

        public RegularEmployeeBusiness()
        {
            _configuration = ConfigurationHelper.GetConfigurationSection("RegularEmployeeInfo");
        }


        public double Compute(double input)
        {
            double salary = _configuration.GetValue<double>("BasicMonthlySalary");
            double tax = _configuration.GetValue<double>("TaxPercentage") / 100.0;
            double dayAbsentEquivalent = _configuration.GetValue<double>("DayAbsentEquivalent");

            double absentDays = input * (salary / dayAbsentEquivalent);
            double finalComputation = (salary - absentDays) - (salary * tax);

            return finalComputation;
        }
    }
}
