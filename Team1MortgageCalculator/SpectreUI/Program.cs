using Spectre.Console;
using MortgageCalculator;

namespace SpectreUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt for loan details first
            var loanAmount = AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter [green]Loan Amount[/]:")
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Value must be greater than 0[/]")));

            var loanTerm = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter [green]Loan Term (in months)[/]:")
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Value must be greater than 0[/]")));

            var interestRate = AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter [green]Interest Rate (annual, in %)[/]:")
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Value must be greater than 0[/]")));

            // Instantiate the MortgageCalc class
            var mortgageCalc = new MortgageCalc(loanAmount, interestRate, loanTerm);

            // Generate the payment schedule
            mortgageCalc.MortgagePaymentSchedule();

            // Display the loan details as a panel
            var loanDetailsPanel = new Panel(
                new Markup($"[bold]Customer Name:[/]\n" +
                           $"{firstName} {lastName}\n" +
                           $"[bold]Customer Email:[/]\n" +
                           $"{email}\n\n" +
                           $"[bold]Loan Details:[/]\n\n" +
                           $"- [blue]Loan Amount[/]: {loanAmount:C}\n" +
                           $"- [blue]Loan Term[/]: {loanTerm} months\n" +
                           $"- [blue]Interest Rate[/]: {interestRate:F2}%\n"))
                .Border(BoxBorder.Rounded)
                .Expand();

            AnsiConsole.Write(loanDetailsPanel);
// Display the amortization schedule as a table
            var table = new Table();
            table.AddColumn("Month");
            table.AddColumn("Payment");
            table.AddColumn("Principal");
            table.AddColumn("Interest");
            table.AddColumn("Total Interest");
            table.AddColumn("Balance");

            foreach (var payment in mortgageCalc.LoanInformation.Payments)
            {
                table.AddRow(
                    payment.Month.ToString(),
                    $"{payment.MonthlyPayment:C}",
                    $"{payment.PrincipalPayment:C}",
                    $"{payment.InterestRatePayment:C}",
                    $"{payment.TotalInterest:C}",
                    $"{payment.RemainingBalance:C}");
            }

            AnsiConsole.Write(table);
        }
    }
}
