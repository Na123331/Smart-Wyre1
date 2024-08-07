using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Calculators;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {   //Liskov Substitution Principle (LSP)
            // All rebate calculators can be used interchangeably without altering the correctness of the program.
            IRebateDataStore rebateDataStore = new RebateDataStore();
            IProductDataStore productDataStore = new ProductDataStore();
            //Open/Closed Principle (OCP)
            // The system is open for extension by allowing new rebate calculators to be added without modifying existing code.
            var calculators = new Dictionary<IncentiveType, IRebateCalculator>
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountCalculator() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateCalculator() },
                { IncentiveType.AmountPerUom, new AmountPerUomCalculator() }
            };

            IRebateService rebateService = new RebateService(rebateDataStore, productDataStore, calculators);

            // Example request
            var request = new CalculateRebateRequest
            {
                RebateIdentifier = "1",
                ProductIdentifier = "A",
                Volume = 10
            };

            // Perform calculation
            var result = rebateService.Calculate(request);

            // Output the result
            Console.WriteLine($"Success: {result.Success}, Rebate Amount: {result.RebateAmount}");
        }
    }
}
