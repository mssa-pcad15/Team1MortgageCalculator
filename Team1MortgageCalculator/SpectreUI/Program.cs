using Spectre.Console;
using Spectre.Console.Cli;
namespace SpectreUI

{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Create the layout
			var layout = new Layout("Root")
				.SplitRows(
					new Layout("Top").SplitColumns(
						new Layout("Left"),
						new Layout("Right")),
					new Layout("Bottom"));
						

			//// Update the left column
			//layout["Left"].Update(
			//	new Panel(
			//		Align.Center(
			//			new Markup("Hello [blue]World![/]"),
			//			VerticalAlignment.Middle))
			//		.Expand());

			// render the layout
			AnsiConsole.Write(layout);
		}
	}
}
