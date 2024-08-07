using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Services
{
    public class RebateService : IRebateService
    {
        private readonly IRebateDataStore _rebateDataStore;
        private readonly IProductDataStore _productDataStore;
        private readonly Dictionary<IncentiveType, IRebateCalculator> _calculators;

        public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore, Dictionary<IncentiveType, IRebateCalculator> calculators)
        {
            _rebateDataStore = rebateDataStore;
            _productDataStore = productDataStore;
            _calculators = calculators;
        }

        public CalculateRebateResult Calculate(CalculateRebateRequest request)
        {
            var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
            var product = _productDataStore.GetProduct(request.ProductIdentifier);

            if (rebate == null || product == null || !_calculators.ContainsKey(rebate.Incentive))
            {
                return new CalculateRebateResult { Success = false };
            }

            var result = _calculators[rebate.Incentive].Calculate(request, rebate, product);

            if (result.Success)
            {
                _rebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
            }

            return result;
        }
    }
}
