using Microsoft.Extensions.Configuration;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Helpers;

namespace Sprout.Exam.Business
{
    public sealed class ContractualEmployeeBusiness : INetIncome
    {
        private readonly IConfiguration _configuration;

        public ContractualEmployeeBusiness()
        {
            _configuration = ConfigurationHelper.GetConfigurationSection("ContractualEmployeeInfo");
        }


        public double Compute(double input)
        {
            double perDayRate = _configuration.GetValue<double>("PerDayRate");
            double finalComputation = perDayRate * input;

            return finalComputation;
        }
    }
}
