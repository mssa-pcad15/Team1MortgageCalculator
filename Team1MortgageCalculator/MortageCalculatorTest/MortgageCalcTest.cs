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
		public void MortageFormulaOutput()
		{
			//arrange
			decimal expected = 0;
			decimal actual = 0;
			//act
			MonthlyPayment();
			//assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void VerfyMonthlyPrincipalPayment()
		{

		}

		[TestMethod]
		public void VerfyMontlyInterestPayment() 
		{ 

		}

		[TestMethod]
		public void VerifyPrincipalAmount()
		{

		}

		[TestMethod]
		public void VerifyInterestAmount()
		{

		}

		[TestMethod]
		public void ValidLoanPayOff()
		{

		}

	}
}

