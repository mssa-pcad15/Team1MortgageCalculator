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

            decimal expectedPrincipalPayment = mortgageCalc.monthlyPayment - (25000.25m * (0.54m / 1200));
            Assert.AreEqual(Math.Round(expectedPrincipalPayment, 2), Math.Round(mortgageCalc.principalPayment, 2));
        }

		[TestMethod]
		public void VerifyTotalAmountPaidOverDurationOfLoan()
		{
            MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

            decimal totalPaid = mortgageCalc.monthlyPayment * 36;
            Assert.AreEqual(Math.Round(totalPaid, 2), 27514.84m);
        }

		[TestMethod]
		public void ValidLoanPayOff()
		{
            // Arrange
            MortgageCalc mortgageCalc = new MortgageCalc(25000.25m, 0.54m, 36);

            // Act
            mortgageCalc.MortgagePaymentSchedule();

            // Assert
            decimal finalBalance = mortgageCalc.LoanInformation.Payments.Last().RemainingBalance;

            Assert.IsTrue(Math.Abs(finalBalance) < 0.01m, $"Final balance is not zero; it is {finalBalance}.");
        }

    }
}

