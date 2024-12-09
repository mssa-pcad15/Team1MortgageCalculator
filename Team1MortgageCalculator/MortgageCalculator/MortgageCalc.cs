using System.Runtime.CompilerServices;

namespace MortgageCalculator
{

    public class LoanInformation
    {
        // add errorhandle for null values
        // redirect to main ui page to request info again 
        public required decimal LoanAmount { get; set; }
        public required decimal InterestRate { get; set; }
        public required int LoanDuration { get; set; }
        public List<PaymentSchedule> Payments { get; set; } = new List<PaymentSchedule>();
    
    }

    public class MortgageCalc
    {
        //add errorhandle for zero or negative inputs
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
     (1 - (decimal)Math.Pow(1 + (double)(LoanInformation.InterestRate / 1200), - LoanInformation.LoanDuration));


        public decimal remainingBalanceAtMonth(int month) => LoanInformation.LoanAmount *
    (decimal)Math.Pow(1 + (double)(LoanInformation.InterestRate / 1200), month) -
    (monthlyPayment * ((decimal)Math.Pow(1 + (double)(LoanInformation.InterestRate / 1200), month) - 1) / (LoanInformation.InterestRate / 1200));


        public decimal interestRatePayment(int month)
        {
            decimal remainingBalance = remainingBalanceAtMonth(month - 1);
            return remainingBalance * (LoanInformation.InterestRate / 1200);
        }

        public decimal principalPayment(int month) => monthlyPayment - interestRatePayment(month);
		////TODO confirm value iniitalization
		public decimal totalInterest(int month)  => totalInterest(month) + interestRatePayment(month);

        
		public void MortgagePaymentSchedule() {
            decimal balance = LoanInformation.LoanAmount;
            decimal totalInterestPaid = 0;

            for (var i = 1; i <= LoanInformation.LoanDuration; i++)
            {
                decimal interestPayment = balance * (LoanInformation.InterestRate / 1200);
                decimal principalPayment = monthlyPayment - interestPayment;
                balance -= principalPayment;
                totalInterestPaid += interestPayment;

                LoanInformation.Payments.Add(
                    new PaymentSchedule()
                    {
                        Month = i,
                        MonthlyPayment = Math.Round(monthlyPayment, 2),
                        PrincipalPayment = Math.Round(principalPayment, 2),
                        InterestRatePayment = Math.Round(interestPayment, 2),
                        TotalInterest = Math.Round(totalInterestPaid, 2),
                        RemainingBalance = Math.Round(balance, 2)
                    }); //this is where you calculate the interest, principal, the remaining balance..
			} 
            
        }

    }


}
