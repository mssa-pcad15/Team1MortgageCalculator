using MortgageCalculator;

namespace MortageCalculatorTest
{
	//TODO create a method to validate user input is empty 2024/12/05
	[TestClass]
	public sealed class MortgageCalcTest
	{
		[TestMethod]
		public void ValidateUserInputNumberic()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

			// arrange
			LoanInformation loanInformation = new LoanInformation();

			// act
			string inputAmount = loanInformation.LoanAmount.ToString();
            string inputInterest = loanInformation.InterestRate.ToString();
            string inputDuration = loanInformation.LoanDuration.ToString();
            //MortgageCalc(princialAmout: 20000, termDuration: 30, interestReate: 5);
            //decimal result = default(decimal);
            // assert

            Assert.IsTrue(decimal.TryParse(inputAmount, out decimal resultAmount));
            Assert.IsTrue(decimal.TryParse(inputInterest, out decimal resultInterest));
            Assert.IsTrue(decimal.TryParse(inputDuration, out decimal resultDuration));

        }


		[TestMethod]
		public void ValidateUserInputNull()
		{
            MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

            // arrange
            LoanInformation loanInformation = new LoanInformation();

            // act
            string inputAmount = loanInformation.LoanAmount.ToString();
            string inputInterest = loanInformation.InterestRate.ToString();
            string inputDuration = loanInformation.LoanDuration.ToString();

			// assert
			Assert.IsNull(inputDuration);
			Assert.IsNull(inputInterest);
			Assert.IsNull(inputAmount);
			

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

