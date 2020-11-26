using System;

namespace XQNT.Finance.Contracts
{
    public interface IDepositCalculator
    {
        /// <summary>
        /// Function returns total amount of money that should be returned to client in the end of payoffPeriod using compound interest.
        /// Compound interest is the addition of interest to the principal sum of a loan or deposit, or in other words, interest on interest.
        /// It is the result of reinvesting interest, rather than paying it out, so that interest in the next period is then earned 
        /// on the principal sum plus previously accumulated interest. Compound interest is standard in finance and economics.
        /// </summary>
        /// <param name="notional">Initial amount of money which is intended to put to the deposit at the start of period.</param>
        /// <param name="interestRate">The rate that is used to multiply notional in the end of compoundingFrequency period.</param>
        /// <param name="payoffPeriod">Total amount of time for which the deposit is put.</param>
        /// <param name="compoundingFrequency">The compounding frequency is the number of times per year (or rarely, another unit of time) 
        /// the accumulated interest is paid out, or capitalized (credited to the account), on a regular basis. 
        /// The frequency could be yearly, half-yearly, quarterly, monthly, weekly, daily.</param>
        /// <returns></returns>
        decimal CalculateFinalPayoff(decimal notional, double interestRate, TimeSpan payoffPeriod, TimeSpan compoundingFrequency);
    }
}
