using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculators
{
    public class FixedCashAmountCalculator : IRebateCalculator
    {
        public CalculateRebateResult Calculate(CalculateRebateRequest request, Rebate rebate, Product product)
        {
            var result = new CalculateRebateResult();

            if (rebate == null || !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount == 0)
            {
                result.Success = false;
            }
            else
            {
                result.Success = true;
                result.RebateAmount = rebate.Amount;
            }

            return result;
        }
    }
}
