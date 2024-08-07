namespace Smartwyre.DeveloperTest.Types
{
    public class Product
    {
        public string Identifier { get; set; }
        public decimal Price { get; set; }
        public SupportedIncentiveType SupportedIncentives { get; set; }
    }
}
