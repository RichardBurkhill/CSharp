using System;

namespace EmployeeModel
{
    public static class IncomeTaxCalculator
    {
        /// <summary>
        /// Calculates the income tax for a given annual income.
        /// This is a placeholder method and should be updated with actual tax rules.
        /// </summary>
        /// <param name="annualIncome">The annual income to calculate tax for.</param>
        /// <returns>The calculated income tax.</returns>
        public static decimal CalculateIncomeTax(decimal annualIncome)
        {
            // --- Placeholder for actual income tax calculation logic ---
            // You would typically implement progressive tax brackets here.
            // For demonstration, let's assume a flat tax rate for income above a certain threshold.

            decimal tax = 0m;
            decimal personalAllowance = 12570m; // Example personal allowance
            decimal basicRateThreshold = 50270m; // Example basic rate threshold
            decimal basicRate = 0.20m; // 20%
            decimal higherRate = 0.40m; // 40%

            if (annualIncome > personalAllowance)
            {
                decimal taxableIncome = annualIncome - personalAllowance;

                if (taxableIncome <= basicRateThreshold - personalAllowance)
                {
                    // Income falls within basic rate band
                    tax = taxableIncome * basicRate;
                }
                else
                {
                    // Income extends into higher rate band
                    decimal basicRateTaxable = basicRateThreshold - personalAllowance;
                    tax += basicRateTaxable * basicRate;

                    decimal higherRateTaxable = taxableIncome - basicRateTaxable;
                    tax += higherRateTaxable * higherRate;
                }
            }

            Console.WriteLine($"Calculating income tax for income: {annualIncome:C}");
            Console.WriteLine($"Personal Allowance: {personalAllowance:C}");
            Console.WriteLine($"Taxable Income: {annualIncome - personalAllowance:C}");
            Console.WriteLine($"Calculated Income Tax: {tax:C}");

            return tax/12; // Return monthly tax amountfor payroll purposes
        }
    }
}