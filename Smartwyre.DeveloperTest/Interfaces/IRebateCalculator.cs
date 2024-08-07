using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Interfaces
{
    public interface IRebateCalculator
    {
        CalculateRebateResult Calculate(CalculateRebateRequest request, Rebate rebate, Product product);
    }
}
