using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;

namespace RetirementBuddy
{
    public class RetirementPlan
    {

        public Dictionary<int, decimal> retirementYearlyIncome;
        public Dictionary<int, decimal> retirementSavings;

        private int currentYear = 2021;

        private string name;
        private int currentAge;
        private decimal nestEgg;
        private double rOR;
        private decimal currentSalary;
        private decimal yearlyContribution;
        private bool percentageCheck;
        private double salaryIncrementPrecentage;
        private int retirementAge;
        private decimal retirementSalary;
        private bool dontSlowDownExpensesCheck;
        private int lessActiveAge;
        private decimal lessActiveStartingSalary;
        private double inflationRate;
        private double cOLA_InflationRate;
        private decimal retirementBalance;
        private decimal additionalPayment;
        private int atYear;
        private bool incrementEveryYearCheck;
        private string scenario;

        DataTable gridView;

        public RetirementPlan(string name, int age, decimal nestEgg, double rOR, decimal currentSalary, decimal yearlyContribution, bool percentageCheck,
                                double salaryIncrementPrecentage, int retirementAge, decimal retirementSalary, bool dontSlowDownExpensesCheck, int lessActiveAge,
                                    decimal lessActiveStartingSalary, double inflationRate, double cOLA_InflationRate, decimal retirementBalance, decimal additionalPayment,
                                        int atYear, bool incrementEveryYearCheck, string scenario)
        {
            this.name = name;
            this.currentAge = age;
            this.nestEgg = nestEgg;
            this.rOR = rOR;
            this.currentSalary = currentSalary;
            this.yearlyContribution = yearlyContribution;
            this.percentageCheck = percentageCheck;
            this.salaryIncrementPrecentage = salaryIncrementPrecentage;
            this.retirementAge = retirementAge;
            this.retirementSalary = retirementSalary;
            this.dontSlowDownExpensesCheck = dontSlowDownExpensesCheck;
            this.lessActiveAge = lessActiveAge;
            this.lessActiveStartingSalary = lessActiveStartingSalary;
            this.inflationRate = inflationRate;
            this.cOLA_InflationRate = cOLA_InflationRate;
            this.retirementBalance = retirementBalance;
            this.additionalPayment = additionalPayment;
            this.atYear = atYear;
            this.incrementEveryYearCheck = incrementEveryYearCheck;
            this.scenario = scenario;

            retirementYearlyIncome = new Dictionary<int, decimal>();
            retirementSavings = new Dictionary<int, decimal>();
            gridView = new DataTable();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Scenario
        {
            get
            {
                return this.scenario;
            }
        }

        public DataTable Calculate()
        {
            decimal beginingBal = nestEgg;
            int year = currentYear;
            int age = currentAge;
            decimal endRetirementBalance = CalculateEndTaxableRetirementBalance(beginingBal, age);
            CreateHeaderRow();
            while (age <= 100 && endRetirementBalance > 0)
            {

                    CreateValueRow(year, age, beginingBal, CalculateInterestGrowth(beginingBal), CalculateWageIncome(age), CalculateRetirementSavingContribution(age),
                    CalculateDesiredRetIncome(age), CalculateSSAIncome(age), CalculateRetAccountWithdrawals(age, beginingBal), CalculateRMDFromSSA(beginingBal, age), CalculateEndTaxableRetirementBalance(beginingBal, age),
                    CalculateYearlyAmountReceivedWithSSA(age, beginingBal), CalculateExtraAmountRequiredByRMD(beginingBal, age));

                retirementSavings.Add(age, CalculateRetirementSavingContribution(age));
                retirementYearlyIncome.Add(age, CalculateDesiredRetIncome(age));

                beginingBal = CalculateEndTaxableRetirementBalance(beginingBal,age);
                age++;
                year++;

            }
            return gridView;
        }

        public decimal CalculateTotalRetirementBalance()
        {
            int age = currentAge;
            int year = currentYear;
            decimal finalBalance = nestEgg;
            while (age < retirementAge)
            {
                finalBalance += CalculateInterestGrowth(finalBalance) + CalculateRetirementSavingContribution(age);
                age += 1;
                year++;

            }
            return finalBalance;
        }

        public double IRS_RMDFactors(int age)
        {
            switch (age)
            {
                case 70: return 27.4;
                case 71: return 26.5;
                case 72: return 25.6;
                case 73: return 24.7;
                case 74: return 23.8;
                case 75: return 22.9;
                case 76: return 22.0;
                case 77: return 21.2;
                case 78: return 20.3;
                case 79: return 19.5;
                case 80: return 18.7;
                case 81: return 17.9;
                case 82: return 17.1;
                case 83: return 16.3;
                case 84: return 15.5;
                case 85: return 14.8;
                case 86: return 14.1;
                case 87: return 13.4;
                case 88: return 12.7;
                case 89: return 12.0;
                case 90: return 11.4;
                case 91: return 10.8;
                case 92: return 10.2;
                case 93: return 9.6;
                case 94: return 9.1;
                case 95: return 8.6;
                case 96: return 8.1;
                case 97: return 7.6;
                case 98: return 7.1;
                case 99: return 6.7;
                case 100: return 6.3;
                case 101: return 5.9;
                case 102: return 5.5;
                case 103: return 5.2;
                case 104: return 4.9;
                case 105: return 4.5;
                case 106: return 4.2;
                case 107: return 3.9;
                case 108: return 3.7;
                case 109: return 3.4;
                case 110: return 3.1;
                case 111: return 2.9;
                case 112: return 2.6;
                case 113: return 2.4;
                case 114: return 2.1;
                case 115: return 1.9;
                default: return 1.9;
            }
            
        }
        private void CreateHeaderRow()
        {
            //Create columns for the gridView.
            gridView.Columns.Add("Year", typeof(int));
            gridView.Columns.Add("Age", typeof(int));
            gridView.Columns.Add("Begining Retirement Balance", typeof(decimal));
            gridView.Columns.Add("Interest(Growth)", typeof(decimal));
            gridView.Columns.Add("Wage Income", typeof(decimal));
            gridView.Columns.Add("Retirement Saving Contribution", typeof(decimal));
            gridView.Columns.Add("Desired Retirement Income", typeof(decimal));
            gridView.Columns.Add("SSA Income", typeof(decimal));
            gridView.Columns.Add("Retirement Account Withdrawals", typeof(decimal));
            gridView.Columns.Add("RMD From SSA", typeof(decimal));
            gridView.Columns.Add("Taxable End Retirement Balance", typeof(decimal));
            gridView.Columns.Add("Yearly Amount Received With SSA", typeof(string));
            gridView.Columns.Add("Extra Amount Required By RMD", typeof(decimal));

           
        }

        private void CreateValueRow(int _year, int _age, decimal _beginingRetirementBalance, decimal _interestGrowth, decimal _wageIncome,
                                        decimal _retirementSavingContribution, decimal _desiredRetirementIncome, decimal _ssaIncome, decimal _retirementAccountWithdrawals,
                                        decimal _rmdFromSSA, decimal _endTaxableRetirementBalance, string _yearlyAmountReceivedWithSSA,
                                        decimal _extraAmountRequiredByRMD)
        {
            DataRow columnRow = gridView.NewRow();


            columnRow[0] = _year;
            columnRow[1] = _age;
            columnRow[2] = Math.Round(_beginingRetirementBalance,2);
            columnRow[3] = Math.Round(_interestGrowth, 2);
            columnRow[4] = Math.Round(_wageIncome,2);
            columnRow[5] = Math.Round(_retirementSavingContribution,2);
            columnRow[6] = Math.Round(_desiredRetirementIncome,2);
            columnRow[7] = Math.Round(_ssaIncome,2);
            columnRow[8] = Math.Round(_retirementAccountWithdrawals,2);
            columnRow[9] = Math.Round(_rmdFromSSA,2);
            columnRow[10] = Math.Round(_endTaxableRetirementBalance,2);
            columnRow[11] = _yearlyAmountReceivedWithSSA;
            columnRow[12] = Math.Round(_extraAmountRequiredByRMD,2);
            gridView.Rows.Add(columnRow);


        }



        public decimal CalculateInterestGrowth(decimal beginingBalance)
        {
            return ((decimal)rOR / 100) * beginingBalance;
        }

        public decimal CalculateWageIncome(int age)
        {
            if(age < retirementAge)
            {
                int compoundTimes = age - currentAge;
                return currentSalary * (decimal)Math.Pow((salaryIncrementPrecentage / 100) + 1, compoundTimes);
            }
            else
            {
                return 0;
            }
        }

        public decimal CalculateRetirementSavingContribution(int age)
        {
            decimal salaryContrib;
            if (percentageCheck)
            {
                salaryContrib = (yearlyContribution / 100) * CalculateWageIncome(age);
            }
            else
            {
                salaryContrib = yearlyContribution;
            }

            decimal totalContribution = salaryContrib;
            if (incrementEveryYearCheck || atYear == (currentYear + age - currentAge))
            {
                totalContribution += additionalPayment;
            }
            return totalContribution;
        }

        public decimal CalculateDesiredRetIncome(int age)
        {
            int compoundTimes = age - retirementAge;
            if (age >= retirementAge)
            {
                if (age < lessActiveAge || dontSlowDownExpensesCheck)
                {
                    return retirementSalary * (decimal)Math.Pow(1+(inflationRate / 100), compoundTimes);

                }
                else
                {
                    compoundTimes = age - lessActiveAge;
                    return lessActiveStartingSalary * (decimal)Math.Pow(1 + (inflationRate / 100), compoundTimes);
                }
            }
            else
            {
                return 0;
            }
        }
        public decimal CalculateSSAIncome(int age)
        {
            double ssaPercentage = 0.25; // a constant value. Say 25% of the highest wage is starting ssa
            int youGetSSAStartingAge = 62;
            int compoundTimes = age - retirementAge;
            if (age >= youGetSSAStartingAge)
            {
                return (decimal)ssaPercentage * CalculateWageIncome(retirementAge -1) * (decimal)Math.Pow(1+(cOLA_InflationRate / 100), compoundTimes);
            }
            else
            {
                return 0;
            }
        }
        public decimal CalculateRetAccountWithdrawals(int age, decimal beginingBalance)
        {
            decimal actualWithdrawalAmount = (CalculateDesiredRetIncome(age) - CalculateSSAIncome(age));
            decimal remainingBalance = beginingBalance + CalculateInterestGrowth(beginingBalance);
            if (remainingBalance >= actualWithdrawalAmount)
            {
                return actualWithdrawalAmount;
            }
            else
            {
                return remainingBalance ;
            }
        }

        public decimal CalculateRMDFromSSA(decimal beginingBalance, int age)
        {
            if (age >= 70)
            {
                return beginingBalance / (decimal)IRS_RMDFactors(age);

            }
            else
            {
                return 0;
            }
        }

        public decimal CalculateEndTaxableRetirementBalance(decimal beginingBalance, int age)
        {
            return beginingBalance + CalculateInterestGrowth(beginingBalance) + CalculateRetirementSavingContribution(age) - CalculateRetAccountWithdrawals(age,beginingBalance);
        }

        public string CalculateYearlyAmountReceivedWithSSA(int age, decimal beginingBalance)
        {
            int incomeInThousands = (int)Math.Round((CalculateSSAIncome(age) + CalculateRetAccountWithdrawals(age,beginingBalance)) / 1000);
            return incomeInThousands.ToString() + "k";
        }

        public decimal CalculateExtraAmountRequiredByRMD(decimal beginingBalance, int age)
        {
            decimal extraRMDRequired = CalculateRMDFromSSA(beginingBalance, age) - CalculateRetAccountWithdrawals(age,beginingBalance);
            if (extraRMDRequired > 0 && age >= 70)
            {
                return extraRMDRequired;
            }
            else
            {
                return 0;
            }
        }

    }
}