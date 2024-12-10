using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MortgageCalculator
{
	internal class RecordKeeper
	{
		//define variables
		private string _path = string.Empty;
		public List<Customer> Customer { get; private set; }

		//Console.WriteLine(System.IO.Path.GetFullPath(Assembly.GetExecutingAssembly().Location));
		//Console.WriteLine(Environment.CurrentDirectory);
		//Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
		//Console.WriteLine(System.Environment.CurrentDirectory);
		//Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);

		//on the user's machine should not produce file path for bin, executed from file folder, Replace is for debug purposes
		public string currentDirectory => System.IO.Path.GetFullPath(Assembly.GetExecutingAssembly().Location).Replace(string.Empty, "SpectreUI\\bin\\Debug\\net8.0");

		//constructor
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

			var filePath = Path.Combine(this._path, $"{customer.Id}");
			try
			{
				if (Directory.Exists(filePath))
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

			//	public void SaveToFile()
			//	{
			//		Path.Combine(this._path, $"{this.Customer}")
			//		try
			//		{
			//			if (Directory.Exists(_path))
			//			{

			//			}
			//		}

			//}

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
}
