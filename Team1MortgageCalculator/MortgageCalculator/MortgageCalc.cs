using System.Runtime.CompilerServices;

namespace MortgageCalculator
{
    [SetsRequiredMembers]
    public class LoanInformation
    {
        public required decimal? LoanAmount { get; private set; }
        public required decimal? InterestRate { get; private set; }
        public required int? LoanDuration { get; private set; }
        this.Payments = new List<PaymentSchedule>();

    }

    public class MortgageCalc
    {
        LoanInformation loanInformation = new LoanInformation();
        public void MortgageCalc(decimal loanAmount, decimal interestRate, int loanDuration)
        {

            loanInformation.LoanAmount = loanAmount;
            loanInformation.InterestRate = interestRate;
            loanInformation.LoanDuration = loanDuration;

        }

        //Total Monthly Payment: (amount loaned) * (rate/1200) / (1-(1*rate/1200)(exponent Number of months)
        //Remaining balance: (Before very first month equals amount of loan)
        //Interest payment: (Previous remaining balance * rate/1200)
        //Principal Payment: (Total monthly payment - Interest payment)
        //Remaining balance each month: (previous remaining balance - principal payments)

        
        
        // keep but will prompt user to provide APR (yearly): decimal monthlyInterestRate = (InterestRate * 100) / 12;
        // TODO: review implicit type conversion
        public decimal MonthlyPayment {get; private set;}  => LoanAmount * (InterestRate / 1200) / Math.Pow((1 - ((1 * InterestRate / 1200), LoanDuration)));


        public void MortgagePaymentSchedule() {
            for (var i = 1; i < LoanDuration; i++)
            {
                Payments.Add()
       
            } 
            
        }
        //Okino i gotta stop liveshare rq my computer crashing I'll save 
    

        public decimal RemainingBalance {get; private set; } => LoanAmount - MonthlyPayment;

        public decimal InterestRatePayment {get; private set;} => RemainingBalance - InterestRate/1200;
        
        public decimal PrincipalPayment {get; private set;} => MonthlyPayment - InterestRatePayment;

        //TODO confirm value iniitalization
        public decimal TotalInterest {get; private set;} => TotalInterest + InterestRatePayment;
        

       

    }

    public void PaymentSchedule {
        MonthlyPayment,
        PrincipalPayment,
        InterestRatePayment, 
        TotalInterest,
        RemainingBalance
    }
}
