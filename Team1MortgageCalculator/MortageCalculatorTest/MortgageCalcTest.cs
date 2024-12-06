using MortgageCalculator;

namespace MortageCalculatorTest
{
	//TODO create a method to validate user input is empty 2024/12/05
	[TestClass]
	public sealed class MortgageCalcTest
	{
		[TestMethod]
		public void MortgageCalConstuctorPopulateLoanInformationPropertyCorrectly()
		{

			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);
			LoanInformation loanInformation = mortgageCalc.LoanInformation;

			
			Assert.AreEqual(25000m,loanInformation.LoanAmount);
            Assert.AreEqual(0.54m,loanInformation.InterestRate);
			Assert.AreEqual(36, loanInformation.LoanDuration);

        }

		[TestMethod]
		public void MortagePaymentFormulaOutputCorrect()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.monthlyPayment;

			decimal expected = 63.69m;

			Assert.AreEqual(expected, actual);

		}


		[TestMethod]
		public void VerfyMonthlyPrincipalPayment()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.monthlyPayment;

			decimal expected = 63.69m;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void VerfyMontlyInterestPayment() 
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.interestRatePayment;

			decimal expected = 5.82m;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void VerifyPrincipalAmount()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.principalPayment;

			decimal expected = 63.69m - 5.82m;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void VerifyInterestAmount()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.totalInterest;

			decimal expected = 2514.31m;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void VerifyTotalAmountPaidOverDurationOfLoan()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			decimal actual = mortgageCalc.totalInterest;

			decimal expected = 27514.56m;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ValidLoanPayOff()
		{

		}

	}
}

