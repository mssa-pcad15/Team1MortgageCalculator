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
            loanInformation = new LoanInformation()
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
        public decimal MonthlyPayment =>
             loanInformation.LoanAmount * (loanInformation.InterestRate / 1200) / 
            (decimal)Math.Pow((1.0 - (double)(loanInformation.InterestRate / 1200))
                 , loanInformation.LoanDuration);
            

        public void MortgagePaymentSchedule() {
            for (var i = 1; i < loanInformation.LoanDuration; i++)
            {
                loanInformation.Payments.Add(
                    new PaymentSchedule() { }//this is where you calculate the interest, principal, the remaining balance..
                    );
       
            } 
            
        }
        //Okino i gotta stop liveshare rq my computer crashing I'll save 
    

        //public decimal RemainingBalance {get; private set; } => LoanAmount - MonthlyPayment;

        //public decimal InterestRatePayment {get; private set;} => RemainingBalance - InterestRate/1200;
        
        //public decimal PrincipalPayment {get; private set;} => MonthlyPayment - InterestRatePayment;

        ////TODO confirm value iniitalization
        //public decimal TotalInterest {get; private set;} => TotalInterest + InterestRatePayment;
        

       

    }


}
