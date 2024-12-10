using MortgageCalculator;

namespace MortgageCalculatorTest
{
	//TODO create a method to validate user input is empty 2024/12/05
	[TestClass]
	public sealed class MortgageCalcTest
	{
		[TestMethod]
		public void MortgageCalConstuctorPopulateLoanInformationPropertyCorrectly()
		{

			MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);
			LoanInformation loanInformation = mortgageCalc.LoanInformation;

			
			Assert.AreEqual(25000m,loanInformation.LoanAmount);
            Assert.AreEqual(5m,loanInformation.InterestRate);
			Assert.AreEqual(60, loanInformation.LoanDuration);

        }

		[TestMethod]
		public void MortagePaymentFormulaOutputCorrect()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

			decimal actual = mortgageCalc.MonthlyPayment;

			decimal expected = 471.78m;

			Assert.AreEqual(expected, actual, 0.01m);

		}


		[TestMethod]
		public void VerfyMonthlyPrincipalPayment()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

			decimal actual = mortgageCalc.PrincipalPayment(1);

			decimal expected = 367.61m;

			Assert.AreEqual(expected, actual, 0.01m);
		}

		[TestMethod]
		public void VerfyMontlyInterestPayment() 
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

			decimal actual = mortgageCalc.InterestRatePayment(1);

			decimal expected = 104.17m;

			Assert.AreEqual(expected, actual, 0.01m);
		}

		[TestMethod]
		public void VerifyPrincipalAmount()
		{
			MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

			decimal actual = mortgageCalc.PrincipalPayment(1);

			decimal expected = 471.78m - 104.17m;

			Assert.AreEqual(expected, actual, 0.01m);
		}

		[TestMethod]
		public void VerifyInterestAmount()
		{
            MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

            decimal expected = 104.17m;
            Assert.AreEqual(Math.Round(expected, 2), Math.Round(mortgageCalc.InterestRatePayment(1), 2));
        }

		[TestMethod]
		public void VerifyTotalAmountPaidOverDurationOfLoan()
		{
            MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

            decimal totalPaid = mortgageCalc.MonthlyPayment * 60;
            Assert.AreEqual(Math.Round(totalPaid, 2), 28306.85m);
        }

		[TestMethod]
		public void ValidLoanPayOff()
		{
            // Arrange
            MortgageCalc mortgageCalc = new MortgageCalc(25000m, 5m, 60);

            // Act
            mortgageCalc.MortgagePaymentSchedule();

            // Assert
            decimal finalBalance = mortgageCalc.LoanInformation.Payments.Last().RemainingBalance;

            Assert.IsTrue(Math.Abs(finalBalance) < 0.01m, $"Final balance is not zero; it is {finalBalance}.");
        }

    }
}

