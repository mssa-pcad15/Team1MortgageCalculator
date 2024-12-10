using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
	public class Customer
	{
		//declare varibales 
		private string _id;
		public required string firstName;
		public required string lastName;
		private string _email;
		private List<MortgageCalc> _customerMortgage;
		private MortgageCalc _createMortgage;

		public event EventHandler CustomerCreate;

		protected virtual void OnCustomerCreate(EventArgs e)
		{
			CustomerCreate?.Invoke(this, e);
		}



		//create get/set methods
		public string Id { get { return _id; } set { _id = value; } }
		public string FirstName { get; set; }
		public string LastName { get; set; } 
		public string Email { get { return _email; } set { _email = value; } }
		public List<MortgageCalc> CustomerMortgage => _customerMortgage;


		//initialize with constructor
		//public void CustomerConstructor(string firstName, string lastName, string email)
		//{
		//	_id = id;
		//	FirstName = firstName;
		//	LastName = lastName;
		//	Email = email;

		//}

		public Customer(string firstName, string lastName, string email, MortgageCalc createMortgage)
		{
			
			Id = Guid.NewGuid().ToString();
			this.FirstName = firstName;
			this.LastName = lastName;
			Email = email;
			this._createMortgage = createMortgage;
			//this._createMortgage = new List<MortgageCalc>();
			//this._createMortgage = CreateMortgage(oanAmount, interestRate, loanDuration);
		}

		public void c_ThresholdReached(object sender, EventArgs e)
		{
			
		}
		

		//public class CustomerConstructor
		//{
		//	public Customer Customer;
		//	public void CustomerConstr(string id, string firstName, string lastName, string email) 
		//	{
		//		Customer = new Customer() {
		//			_id = id,
		//			FirstName = firstName,
		//			LastName = lastName,
		//			Email = email,
		//		}
		//	}

		//}

		//write method to get loan information
		public List<string> LoanStatus(string id, string email)
		{
			//read from persistant file TO BE CREATED class to write to file
			//MortgageCalc mortgageCalc = new MortgageCalc();
			List<string> loanStatus = new List<string>();
			if (Id == id && Email == email)
			{
				loanStatus.Add("");
			}
			return loanStatus;
			

		}

		
		public void CreateMortgage(decimal loanAmount, decimal interestRate, int loanDuration)
		{
			var createMortgage = new MortgageCalc(loanAmount, interestRate, loanDuration);
			
			_customerMortgage.Add(createMortgage);
		}

		
		public void RemoveMortgage(string id, int index) 
		{
			this._customerMortgage.RemoveAt(index);
		}


		
		public void LoanRepayment(string id, int index)
		{
			//add condtional from loan repayment
			this._customerMortgage.RemoveAt(index);
		}
	}
}
