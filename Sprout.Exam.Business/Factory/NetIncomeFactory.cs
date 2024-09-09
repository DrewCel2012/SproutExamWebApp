using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Factory
{
    public sealed class NetIncomeFactory
    {
        public static INetIncome GetNetIncomeType(EmployeeType type)
        {
            return type switch
            {
                EmployeeType.Regular =>
                    new RegularEmployeeBusiness(),

                EmployeeType.Contractual =>
                    new ContractualEmployeeBusiness(),

                _ => null
            };
        }
    }
}
