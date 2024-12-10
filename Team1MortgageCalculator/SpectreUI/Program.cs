using MortgageCalculator;
using Spectre.Console;
namespace SpectreUI

{
    internal class Program
    {
        static void Main(string[] args)
        {

            var firstName = AnsiConsole.Prompt(
            new TextPrompt<string>("What's your first name?"));
            var lastName = AnsiConsole.Prompt(
            new TextPrompt<string>("What's your last name?"));
            var email = AnsiConsole.Prompt(
                new TextPrompt<string>("What's your email?"));

            // Echo the name and age back to the terminal
            AnsiConsole.WriteLine($"{firstName} {lastName}: {email}?");

            var confirmation = AnsiConsole.Prompt(
                new TextPrompt<bool>("Is the above information correct?")
                    .AddChoice(true)
                    .AddChoice(false)
                    .DefaultValue(true)
                    .WithConverter(choice => choice ? "y" : "n"));

            // Echo the confirmation back to the terminal
            Console.WriteLine(confirmation ? "Verified correct info. Please continue" : "Info is not correct.");
            if (confirmation == false)
            {
                Console.WriteLine("Please restart program");
            }
            else
            {
                decimal loanAmount = AnsiConsole.Prompt(
new TextPrompt<decimal>("Please enter the loan amount: "));
                decimal interestRate = AnsiConsole.Prompt(
    new TextPrompt<decimal>("Please enter the interest rate: "));
                int loanDuration = AnsiConsole.Prompt(
                    new TextPrompt<int>("Please enter the loan duration (in months):"));
                MortgageCalc m = new MortgageCalc(loanAmount, interestRate, loanDuration);

                // Create the layout
                var layout = new Layout("Root")
                    .SplitRows(
                        new Layout("Top").SplitColumns(
                            new Layout("Left"),
                            new Layout("Right")),
                        new Layout("Bottom"));


                layout["Left"].Update(
        new Panel(
            Align.Center(
                new Markup("[blue]Customer Info:[/] \n" + $"{firstName} {lastName} \n{email}"),
                VerticalAlignment.Top))
            .Expand());

                layout["Right"].Update(
    new Panel(
    Align.Center(
    new Markup("[blue]Mortgage Input:[/] \n" + $"Loan Amount: {loanAmount} \n Interest Rate: {interestRate} \n Loan Duration: {loanDuration}"
    + $"\n Your monthly payments are: {m.monthlyPayment}"),
    VerticalAlignment.Top))
    .Expand());
                    layout["Bottom"].Update(
        new Panel(
        Align.Center(
        new Markup("[blue]Mortgage Payment Summary:[/]" + $"\n{m.LoanInformation.Payments.Count}"),
        VerticalAlignment.Top))
        .Expand());

                // render the layout
                AnsiConsole.Write(layout);
            }
        }
    }
}
