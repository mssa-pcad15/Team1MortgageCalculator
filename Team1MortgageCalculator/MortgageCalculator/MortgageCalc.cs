namespace MortgageCalculator
{
    public class LoanInformation
    {
        public decimal? LoanAmount { get; set; }
        public decimal? InterestRate { get; set; }
        public int? LoanDuration { get; set; }

    }

    public class MortgageCalc
    {
        LoanInformation loanInformation = new LoanInformation();
        public MortgageCalc(decimal loanAmount, decimal interestRate, int loanDuration)
        {

            loanInformation.LoanAmount = loanAmount;
            loanInformation.InterestRate = interestRate;
            loanInformation.LoanDuration = loanDuration;
        }
    }
}
