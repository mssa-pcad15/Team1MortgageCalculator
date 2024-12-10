using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System
=======
>>>>>>> b2469e0a96c39df928c55f7f4252f281f97a9c15

namespace MortgageCalculator
{
	internal class Bank
	{
<<<<<<< HEAD
		MortgageCalc mortgageCalc = new MortgageCalc(10000m, 5m, 30);
		LoanInformation loanInformation = new LoanInformation(10000m, 5m, 30);
		

		public decimal CalculateTotalInterest()
		{
			return mortgageCalc.LoanInformation.LoanAmount * Math.Pow((double)(1 + mortgageCalc.LoanInformation.InterestRate), (mortgageCalc.LoanInformation.LoanDuration / 12) - mortgageCalc.LoanInformation.LoanAmount;
=======
		MortgageCalc mortgageCalc = new MortgageCalc();

		public CalculateTotalInterest()
		{
>>>>>>> b2469e0a96c39df928c55f7f4252f281f97a9c15
		}
	}
}
