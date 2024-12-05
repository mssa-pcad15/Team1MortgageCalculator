namespace MortageCalculatorTest
{
	//TODO create a method to validate user input is empty 2024/12/05
	[TestClass]
	public sealed class MortgageCalcTest
	{
		[TestMethod]
		public void ValidateUserInputNumberic()
		{
			// arrange

			// act
			string input = MortgageCalc(princialAmout: 20000, termDuration: 30, interestReate: 5);
			//decimal result = default(decimal);
			// assert

			Assert.IsTrue(decimal.TryParse(input, out decimal result));

		}


		[TestMethod]
		public void ValidateUserInputNull()
		{
			// arrange

			// act
			string input =

			// assert

			Assert.IsNull(input);
			

		}

		[TestMethod]
		public void MortageFormulaOutput()
		{

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

