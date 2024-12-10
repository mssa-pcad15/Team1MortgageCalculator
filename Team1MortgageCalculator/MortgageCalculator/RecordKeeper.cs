using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MortgageCalculator
{
	internal class RecordKeeper
	{
		//define variables
		private string _path = string.Empty;


		//constructor
<<<<<<< Updated upstream
=======
		public RecordKeeper()
		{
			this._path = currentDirectory;
			this.Customer = new List<Customer>();
		}


		//triggered by event handler in customer class
		//combine current directory with customer name for full file path
		//check if directory exist 
		//check if file path exist if not create if exist overwrite

		public void SaveToFile(Customer customer)
		{

			var filePath = Path.Combine(this._path, $"{customer.Id}")
			try
			{
				if(Directory.Exists(filePath))
				{
					JsonSerializer.Serialize(customer,
						new JsonSerializerOptions
						{
							WriteIndented = true,
							IncludeFields = true,

						});
				}
			}
			catch (FileNotFoundException fnf)
			{
				Console.WriteLine(fnf.Message);
			}
		}



>>>>>>> Stashed changes
		//public RecordKeeper {
		//	try
		//	{
		//		// Get the current directory.
		//		string path = Directory.GetCurrentDirectory();
		//		string target = @"c:\temp";
		//		Console.WriteLine("The current directory is {0}", path);
		//			if (!Directory.Exists(target))
		//			{
		//				Directory.CreateDirectory(target);
		//			}
		
		//		// Change the current directory.
		//		Environment.CurrentDirectory = (target);
		//		if (path.Equals(Directory.GetCurrentDirectory()))
		//		{
		//			Console.WriteLine("You are in the temp directory.");
		//		}

		//		else
		//		{
		//			Console.WriteLine("You are not in the temp directory.");
		//		}
		//	}
		//	catch (Exception e)
		//	{
		//		Console.WriteLine("The process failed: {0}", e.ToString());
		//	}
		//}

		//method to retrieve Customer or implement with creation of customer


		//method to update records

		//method to delete records

		//method to delete all records
		
	}
}
