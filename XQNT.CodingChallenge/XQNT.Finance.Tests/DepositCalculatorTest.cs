using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace XQNT.Finance.Tests
{
    [TestClass]
    
    public class DepositCalculatorTest
    {
        private readonly DepositCalculator _depositCalculator;
        public DepositCalculatorTest() {
            _depositCalculator = new DepositCalculator();
        }
        //In order to verify answers I needed to use online calculators but they only provide results in 2 digit precision after comma.
        //So for comparison purposes actual numbers had to be rounded into 2 digits after comma.
        //https://www.investor.gov/financial-tools-calculators/calculators/compound-interest-calculator
        //https://www.thecalculatorsite.com/finance/calculators/compoundinterestcalculator.php

        [TestMethod]
        public void Test_1YearOnceRate10()
        {
            //Arrange
            var notional = 100;
            var interestRate = 10;
            var payoffPeriod = new TimeSpan(365,0,0,0);
            var compoundingFrequency = new TimeSpan(365, 0, 0, 0);
            var expected = 110m;

            //act
            var actual = _depositCalculator.CalculateFinalPayoff(notional, interestRate, payoffPeriod, compoundingFrequency);
            
            //assert
            Assert.AreEqual(expected, Math.Round(actual,2));
        }
        [TestMethod]
        public void Test_10YearsOnceAYearRate10() {
            //Arrange
            var notional = 100;
            var interestRate = 10;
            var payoffPeriod = new TimeSpan(10);
            var compoundingFrequency = new TimeSpan(1);//one tick as one year
            var expected = 259.37m;

            //act
            var actual = _depositCalculator.CalculateFinalPayoff(notional, interestRate, payoffPeriod, compoundingFrequency);

            //assert
            Assert.AreEqual(expected, Math.Round(actual, 2));
        }
        [TestMethod]
        public void Test_2YearsQuarterlyRate10() {
            //arrange
            var notional = 100;
            var interestRate = 10;
            var payoffPeriod = new TimeSpan(8);//since in two years 8 quarters 
            var compoundingFrequency = new TimeSpan(1);
            var expected = 214.36m;

            //act
            var actual = _depositCalculator.CalculateFinalPayoff(notional, interestRate, payoffPeriod, compoundingFrequency);

            Assert.AreEqual(expected, Math.Round(actual, 2));
        }
        [TestMethod]
        public void Test_2YearsMonthlyRate10() {
            //arrange
            var notional = 100;
            var interestRate = 10;
            var payoffPeriod = new TimeSpan(24); //since in two years 24 month
            var compoundingFrequency = new TimeSpan(1);
            var expected = 984.97m;

            //act
            var actual = _depositCalculator.CalculateFinalPayoff(notional, interestRate, payoffPeriod, compoundingFrequency);

            Assert.AreEqual(expected, Math.Round(actual, 2));
        }
    }
}
