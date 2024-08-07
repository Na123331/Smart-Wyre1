Open/Closed Principle (OCP)
The system is open for extension by allowing new rebate calculators to be added without modifying existing code.
var calculators = new Dictionary<IncentiveType, IRebateCalculator>
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountCalculator() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateCalculator() },
                { IncentiveType.AmountPerUom, new AmountPerUomCalculator() }
            };
Liskov Substitution Principle (LSP)
All rebate calculators can be used interchangeably without altering the correctness of the program.
IRebateCalculator calculator = new FixedCashAmountCalculator();
CalculateRebateResult result = calculator.Calculate(request, rebate, product);
