using System.Runtime.CompilerServices;

namespace MortgageCalculator
{

    public class LoanInformation
    {
        public required decimal LoanAmount { get;  set; }
        public required decimal InterestRate { get;  set; }
        public required int LoanDuration { get;  set; }
        public List<PaymentSchedule> Payments = new List<PaymentSchedule>();
	}

    public class MortgageCalc
    {
        public LoanInformation LoanInformation;
        public MortgageCalc(decimal loanAmount, decimal interestRate, int loanDuration)
        {
            LoanInformation = new LoanInformation()
            {
                InterestRate = interestRate,
                LoanAmount = loanAmount,
                LoanDuration = loanDuration
            };
        }

        //Total Monthly Payment: (amount loaned) * (rate/1200) / (1-(1*rate/1200)(exponent Number of months)
        //Remaining balance: (Before very first month equals amount of loan)
        //Interest payment: (Previous remaining balance * rate/1200)
        //Principal Payment: (Total monthly payment - Interest payment)
        //Remaining balance each month: (previous remaining balance - principal payments)

        // keep but will prompt user to provide APR (yearly): decimal monthlyInterestRate = (InterestRate * 100) / 12;
        // TODO: review implicit type conversion
        public decimal monthlyPayment =>
             LoanInformation.LoanAmount * (LoanInformation.InterestRate / 1200) / 
            (decimal)Math.Pow((1.0 - (double)(LoanInformation.InterestRate / 1200))
                 , LoanInformation.LoanDuration);
		public decimal remainingBalance => LoanInformation.LoanAmount - monthlyPayment;
		public decimal interestRatePayment => remainingBalance - LoanInformation.InterestRate / 1200;
		public decimal principalPayment  => monthlyPayment - interestRatePayment;
		////TODO confirm value iniitalization
		public decimal totalInterest  => totalInterest + interestRatePayment;

        
		public void MortgagePaymentSchedule() {
            for (var i = 1; i < LoanInformation.LoanDuration; i++)
            {
                LoanInformation.Payments.Add(
                    new PaymentSchedule()
                    {
                        Month = i,
                        MonthlyPayment = Math.Round(monthlyPayment, 2),
                        PrincipalPayment = Math.Round(principalPayment, 2),
                        InterestRatePayment = Math.Round(interestRatePayment, 2),
					    TotalInterest = Math.Round(totalInterest, 2),
                }); //this is where you calculate the interest, principal, the remaining balance..
			} 
            
        }

    }


}
