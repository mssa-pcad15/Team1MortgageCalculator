
namespace MortgageCalculator
{
    public class PaymentSchedule
    {
        public int Month { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal InterestRatePayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal RemainingBalance { get; set; }

    }
}