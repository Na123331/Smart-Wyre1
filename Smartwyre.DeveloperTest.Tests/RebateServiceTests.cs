using NUnit.Framework;
using Moq;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Calculators;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests
{
    [TestFixture]
    public class RebateServiceTests
    {
        private Mock<IRebateDataStore> _rebateDataStoreMock;
        private Mock<IProductDataStore> _productDataStoreMock;
        private Dictionary<IncentiveType, IRebateCalculator> _calculators;
        private RebateService _rebateService;

        [SetUp]
        public void Setup()
        {
            _rebateDataStoreMock = new Mock<IRebateDataStore>();
            _productDataStoreMock = new Mock<IProductDataStore>();

            _calculators = new Dictionary<IncentiveType, IRebateCalculator>
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountCalculator() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateCalculator() },
                { IncentiveType.AmountPerUom, new AmountPerUomCalculator() }
            };

            _rebateService = new RebateService(_rebateDataStoreMock.Object, _productDataStoreMock.Object, _calculators);
        }

        [Test]
        public void Calculate_FixedCashAmount_ReturnsSuccess()
        {
            // Arrange
            var request = new CalculateRebateRequest { RebateIdentifier = "1", ProductIdentifier = "A", Volume = 10 };
            var rebate = new Rebate { Incentive = IncentiveType.FixedCashAmount, Amount = 100 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };

            _rebateDataStoreMock.Setup(x => x.GetRebate("1")).Returns(rebate);
            _productDataStoreMock.Setup(x => x.GetProduct("A")).Returns(product);

            // Act
            var result = _rebateService.Calculate(request);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(100, result.RebateAmount);
        }

        // Additional tests for other rebate types...
    }
}
