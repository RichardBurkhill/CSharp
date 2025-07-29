using System;

namespace EmployeeApi.Models
{
    public static class NICalculator
    {
        // 2024/25 Monthly thresholds (for Category A)
        private const decimal PrimaryThreshold = 1048m;   // Employee pays NI above this
        private const decimal UpperEarningsLimit = 4189m; // Employee pays lower NI above this
        private const decimal SecondaryThreshold = 758m;  // Employer pays NI above this

        private const decimal EmployeeRate = 0.08m;        // 8% between PT and UEL
        private const decimal EmployeeUpperRate = 0.02m;   // 2% above UEL

        private const decimal EmployerRate = 0.138m;       // 13.8% above ST

        public static (decimal employeeNi, decimal employerNi) Calculate(decimal grossPay)
        {
            decimal employeeNi = 0;
            decimal employerNi = 0;

            // --- Employee NI Calculation ---
            if (grossPay > PrimaryThreshold)
            {
                if (grossPay <= UpperEarningsLimit)
                {
                    employeeNi = (grossPay - PrimaryThreshold) * EmployeeRate;
                }
                else
                {
                    // Between PT and UEL
                    decimal band1 = (UpperEarningsLimit - PrimaryThreshold) * EmployeeRate;
                    // Above UEL
                    decimal band2 = (grossPay - UpperEarningsLimit) * EmployeeUpperRate;
                    employeeNi = band1 + band2;
                }
            }

            // --- Employer NI Calculation ---
            if (grossPay > SecondaryThreshold)
            {
                employerNi = (grossPay - SecondaryThreshold) * EmployerRate;
            }

            return (Math.Round(employeeNi, 2), Math.Round(employerNi, 2));
        }
    }
}