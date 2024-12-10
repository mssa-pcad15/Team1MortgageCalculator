using Spectre.Console;
using MortgageCalculator;
<<<<<<< HEAD

=======
using System.Reflection;
using System.Runtime.InteropServices;
>>>>>>> b2469e0a96c39df928c55f7f4252f281f97a9c15
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

<<<<<<< HEAD
			// Echo the name and age back to the terminal
			AnsiConsole.WriteLine($"{firstName} {lastName}: {email}?");
=======
			Console.WriteLine(System.IO.Path.GetFullPath(Assembly.GetCallingAssembly().Location));
			Console.WriteLine(Environment.CurrentDirectory);
			Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
			//Console.WriteLine(System.Environment.CurrentDirectory);
			//Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
			



			var selcetion = AnsiConsole.Prompt(
				new MultiSelectionPrompt<string>()
					.Title("What are your [green]favorite fruits[/]?")
					.NotRequired() 
					.PageSize(10)
					.AddChoices(new[] {
			"Apple", "Apricot", "Avocado",
			"Banana", "Blackcurrant", "Blueberry",
			"Cherry", "Cloudberry", "Coconut",
		}));

			userInformation.LoanAmount = AnsiConsole.Prompt(
					new TextPrompt<decimal>("Loan Amount: ")
						.Validate((n) => n != 0 ?
						ValidationResult.Success() :
						ValidationResult.Error("The loan amount must be greater than zero")));
			userInformation.Term = AnsiConsole.Prompt(
					new TextPrompt<int>("Term of the Loan: ")
						.Validate((n) => n != 0 ?
						ValidationResult.Success() :
						ValidationResult.Error("The term of the loan must be greater than zero")));

			userInformation.InterestRate = AnsiConsole.Prompt(
					new TextPrompt<decimal>("Interest Rate: ")
						.Validate((n) => n != 0 ?
						ValidationResult.Success() :
						ValidationResult.Error("The Loan amount must be greate than zero")));

			//MortgageCalculator.MortgageCalc mortgageCalc = new();
				
			//switch statement 



			//define global variables

			// Create the layout
			//var layout = new Layout("Root")
			//	.SplitRows(
			//		new Layout("Top").SplitColumns(
			//			new Layout("Left"),
			//			new Layout("Right")),
			//		new Layout("Bottom"));


			//// Update the left column
			//layout["Left"].Update(
			//	new Panel(
			//		Align.Center(
			//			new Markup("Hello [blue]World![/]"),
			//			VerticalAlignment.Middle))
			//		.Expand());
>>>>>>> b2469e0a96c39df928c55f7f4252f281f97a9c15

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

				var layout = new Layout()
					.SplitColumns(
					new Layout("Left"),
					new Layout("Right")
					);
				// Update the left column
				layout["Left"].Update(
					new Panel(
						Align.Center(
							new Markup($"[green]Customer Info:[/]\n" +
									   $"[blue]Customer Name:[/]\n" +
									   $"{firstName} {lastName}\n" +
									   $"[blue]Customer Email:[/]\n" +
									   $"{email}\n\n" +
									   $"[green]Loan Details:[/]\n\n" +
									   $"[blue]Loan Amount[/]: {loanAmount:C}\n" +
									   $"[blue]Loan Term[/]: {loanTerm} months\n" +
									   $"[blue]Interest Rate[/]: {interestRate:F2}%\n"),
							VerticalAlignment.Middle))
						.Expand());

				// Calculate proportions for the breakdown chart
				decimal totalPrincipal = mortgageCalc.LoanInformation.LoanAmount;
				decimal totalInterest = mortgageCalc.TotalInterestPaid;
				decimal totalCost = mortgageCalc.TotalCost;

				// Calculate percentages
				decimal principalPercentage = (totalPrincipal / totalCost) * 100;
				decimal interestPercentage = (totalInterest / totalCost) * 100;

				// Update the right column
				layout["Right"].Update(
					new Panel(
						Align.Center(
							new Rows(
								new Markup($"[green]Monthly Payment:[/]\n" +
										   $"{mortgageCalc.MonthlyPayment:C}\n" +
										   $"[blue]Total Principal:[/]\n" +
										   $"{totalPrincipal:C}\n" +
										   $"[blue]Total Interest:[/]\n" +
										   $"{totalInterest:C}\n" +
										   $"[blue]Total Cost:[/]\n" +
										   $"{totalCost:C}\n"),
								new BreakdownChart()
									.Width(60)
									.AddItem("Principal", (double)principalPercentage, Color.Green)
									.AddItem("Interest", (double)interestPercentage, Color.Blue)
							)
						)
					)
					.Expand()
				);

				// Render the layout
				AnsiConsole.Write(layout);

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

				var seeSchedule = AnsiConsole.Prompt(
				new TextPrompt<bool>($"Would you like to see your {loanTerm} month payment schedule?")
					.AddChoice(true)
					.AddChoice(false)
					.DefaultValue(true)
					.WithConverter(choice => choice ? "y" : "n"));

				// Echo the confirmation back to the terminal
				Console.WriteLine(seeSchedule ? "Here is your payment schedule:" : "Please exit the program.");
				if (seeSchedule == false)
				{
					System.Environment.Exit(0);
				}
				else
				{
					// Render the table to the console
					AnsiConsole.Write(table);
				}
			}
		}
	}
}
