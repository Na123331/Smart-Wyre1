using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public class ProductDataStore : IProductDataStore
    {
        public Product GetProduct(string productIdentifier)
        {
            // Dummy implementation for example purposes
            return new Product { Identifier = productIdentifier, Price = 50, SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
        }
    }
}
