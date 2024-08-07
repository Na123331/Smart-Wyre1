using System;

namespace Smartwyre.DeveloperTest.Types
{
    [Flags]
    public enum SupportedIncentiveType
    {
        FixedCashAmount = 1,
        FixedRateRebate = 2,
        AmountPerUom = 4
    }
}
