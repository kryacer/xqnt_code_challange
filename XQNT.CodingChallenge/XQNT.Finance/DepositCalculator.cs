using System;
using XQNT.Finance.Contracts;

namespace XQNT.Finance
{
    public class DepositCalculator : IDepositCalculator {
        public decimal CalculateFinalPayoff(decimal notional, double interestRate, TimeSpan payoffPeriod, TimeSpan compoundingFrequency) {
            if (interestRate > 1)
                interestRate /= 100;

            double power = (double) payoffPeriod.Ticks / compoundingFrequency.Ticks;

            return notional * (decimal) Math.Pow(1 + interestRate, power);
        }
    }
}
