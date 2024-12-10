using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MortgageCalculator
{
	internal class Bank
	{
		public const decimal latePaymentRate =  5m;


		MortgageCalc mortgageCalc = new MortgageCalc(10000m, 5m, 30);
		//LoanInformation loanInformation = new LoanInformation(10000m, 5m, 30);


		public decimal CalculateTotalInterest() => mortgageCalc.LoanInformation.LoanAmount * (decimal)Math.Pow((double)(1 + mortgageCalc.LoanInformation.InterestRate), decimal.ToDouble(mortgageCalc.LoanInformation.LoanDuration / 12m)) - mortgageCalc.LoanInformation.LoanAmount;

		public decimal CalculateTotalPrincipalPayment() => mortgageCalc.PrincipalPayment(1) * mortgageCalc.LoanInformation.LoanDuration;

		public decimal CalculateTotalCostLoan() => mortgageCalc.TotalCost;

		public decimal CalculationLatePaymentCharges(bool lateIndicator, int month)
		{

			if (lateIndicator && DateTime.Now.Day < 10)
			{
				return mortgageCalc.PrincipalPayment(month) * latePaymentRate + mortgageCalc.PrincipalPayment(month);
			}
			else {
				return mortgageCalc.PrincipalPayment(month) * latePaymentRate + mortgageCalc.PrincipalPayment(month) + 50m;

			}
		}
	}
}
