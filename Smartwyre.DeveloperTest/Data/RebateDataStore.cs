using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public class RebateDataStore : IRebateDataStore
    {
        public Rebate GetRebate(string rebateIdentifier)
        {
            // Dummy implementation for example purposes
            return new Rebate { Identifier = rebateIdentifier, Incentive = IncentiveType.FixedCashAmount, Amount = 100 };
        }

        public void StoreCalculationResult(Rebate rebate, decimal rebateAmount)
        {
            // Dummy implementation for example purposes
        }
    }
}
