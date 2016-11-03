using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bank_System
{
	class DOB
	{
		private int day;
		private int month;
		private int year;
		private string dateofBirth;
		private bool dateFlag = false;
		public DOB(int year, int month, int day)
		{
			this.day = day;
			this.month = month;
			this.year = year;
		}
		public string getDOB()
		{
			return dateofBirth;
		}  

		public bool set()
		{
			try
			{

				DateTime date = new DateTime(year, month, day);
				string y = date.Year.ToString();
				string m = date.Month.ToString();
				string d = date.Day.ToString();
				dateofBirth = d + "/" + m + "/" + y;
				dateFlag = true;
				return dateFlag;
			}
			catch
			{
				dateofBirth = "BAD DATE";
				dateFlag = false;
				return dateFlag;
			}

		}
	}

	static class IDGENERATOR
	{

		private static string debitID = "db";
		private static string creditID = "cr";
		private static string savingsID = "sav";
		private static string yearNow;
		private static string monthNow;
		private static string serial_no;
		private static int serial=00001;

		public static string Generate(int type)
		{
			DateTime d = DateTime.Now;
			d = d.Date;
			yearNow = d.Year.ToString();
			monthNow = d.Month.ToString();
			string s = String.Format("{0:D5}", serial);
			if(type == 0)
			{
				string id = debitID + "-" + yearNow + "-" + monthNow + "-" + s;
				serial_no = id;
				Console.WriteLine(id);
				serial++;
			}
			else if(type == 1)
			{
				string id = creditID + "-" + yearNow + "-" + monthNow + "-" + s;
				serial_no = id;
				Console.WriteLine(id);
				serial++;
			}
			else if(type == 2)
			{
				string id = savingsID + "-" + yearNow + "-" + monthNow + "-" + s;
				serial_no = id;
				Console.WriteLine(id);
				serial++;
			}
			else
			{
				Console.WriteLine("INVALID");
			}


			return serial_no;
		}
	}

	abstract class Account
	{
		private readonly string name;
		private readonly string ID;
		private readonly string DOB;
		private readonly string nominee;
		protected double balance;

		public Account()
		{

		}
		public Account(string name, string ID,string DOB, string nominee,double balance)
		{
			this.name = name;
			this.ID = ID;
			this.DOB = DOB;
			this.nominee = nominee;
			this.balance = balance;
		}
		public string GetID()
		{
			return ID;
		}

		public string GetName()
		{
			return name;
		}
		public string GetDOB()
		{
			return DOB;
		}
		public string GetNominee()
		{
			return nominee;
		}
		public double GetBalance()
		{
			return balance;
		}
		public abstract bool deposit(double amount);
		public abstract bool withdraw(double amount);
		public void printAccount()
		{
			Console.Clear();
			if (ID.Contains ("db")) 
			{
				Console.WriteLine ("Account Type: Debit");
			}
			else if(ID.Contains("cr"))
			{
				Console.WriteLine ("Account Type: Credit");
			}
			else
			{
				Console.WriteLine ("Account Type: Savings");
			}
			Console.WriteLine("Name: {0}", name);
			Console.WriteLine("DOB: {0}",DOB);
			Console.WriteLine("ID: {0}",ID);
			Console.WriteLine("Nominee: {0}",nominee);
			Console.WriteLine("Balance: {0}",balance);
			Console.Write("\n");
			System.Threading.Thread.Sleep (1000);
		}
	}

	class Debit : Account
	{
		private double DebitB;
		private double TransactionLimit = 20000;

		public Debit()
		{

		}
		public Debit(string name, string ID, string DOB, string nominee, double balance) : base(name, ID, DOB, nominee, balance)
		{

		}
		public override bool deposit(double amount)
		{

			DebitB = GetBalance();
			TransactionLimit = TransactionLimit - amount;
			if (TransactionLimit >=0 && (DebitB+ amount) <= 100000)
			{
				DebitB += amount;
				balance = DebitB;
				return true;
			}
			else
			{
				TransactionLimit = TransactionLimit + amount;
				return false;
			}

		}
		public override bool withdraw(double amount)
		{
			DebitB = GetBalance();
			TransactionLimit = TransactionLimit - amount;
			if (TransactionLimit >= 0 && DebitB >= amount)
			{
				DebitB -= amount;
				balance = DebitB;
				return true;
			}
			else
			{
				TransactionLimit = TransactionLimit + amount;
				return false;
			}

		}


	}

	class Credit : Account
	{
		private double CreditB;
		private double TransactionLimit = 20000;

		public Credit()
		{

		}
		public Credit(string name, string ID, string DOB, string nominee, double balance) : base(name, ID ,DOB, nominee, balance)
		{

		}
		public override bool deposit(double amount)
		{
			CreditB = GetBalance();
			TransactionLimit = TransactionLimit - amount;
			if (TransactionLimit >= 0)
			{
				CreditB += amount;
				balance = CreditB;
				return true;
			}
			else
			{
				TransactionLimit = TransactionLimit + amount;
				return false;
			}


		}
		public override bool withdraw(double amount)
		{
			CreditB = GetBalance();
			TransactionLimit = TransactionLimit - amount;
			if (TransactionLimit >= 0 && CreditB >= -100000)
			{
				CreditB -= amount;
				balance = CreditB;
				return true;
			}
			else
			{
				TransactionLimit = TransactionLimit + amount;
				return false;
			}

		}

	}

	class Savings:Account
	{
		public double Savingsb;
		public Savings()
		{

		}
		public Savings(string name, string ID, string DOB, string nominee, double balance) : base(name, ID, DOB, nominee, balance)
		{

		}
		public override bool deposit(double amount)
		{
			Savingsb = GetBalance();
			Savingsb += amount;
			balance = Savingsb;
			return true;
		}
		public override bool withdraw(double amount)
		{
			Savingsb = GetBalance();
			if (Savingsb >= amount)
			{
				Savingsb -= amount;
				balance = Savingsb;
				return true;
			}
			else
			{
				return false;
			}
		}

	}

	class Bank
	{
		//public static int count = 50;
		public static ArrayList acccount = new ArrayList();

		public static int checkException()
		{
			string c;
			c = Console.ReadLine();
			int x;
			bool parse1 = Int32.TryParse(c, out x);
			while (!parse1)
			{
				Console.WriteLine("Invalid Choice");
				Console.Write("Please enter your choice again :");
				c = Console.ReadLine();
				int x1;
				bool parse = Int32.TryParse(c, out x1);
				//Console.Write("\n");
				if (parse)
				{
					break;
				}
			}
			int num = Convert.ToInt32(c); 
			return num;
		}
		public static void create_account()
		{

			string name;
			int d, m, y;
			//string dob;
			string nominee;
			double balance=0;
			string id;
			//string c;
			int choice;
			Console.WriteLine("0. Debit Account");
			Console.WriteLine("1. Credit Account");
			Console.WriteLine("2. Savings Account");
			Console.Write("What is your Option: ");
			//c = Console.ReadLine();
			choice = checkException();
			if (choice == 0)
			{
				Console.Write("Account Name: ");
				name = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.Write("Nominee: ");
				nominee = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.WriteLine("Date of Birth:");

				Console.Write("Day(DD):");
				d = checkException();
				//Console.WriteLine("\n");

				Console.Write("Month(MM):");
				m = checkException();
				//Console.WriteLine("\n");

				Console.Write("Year(YYYY):");
				y = checkException();
				//Console.WriteLine("\n");

				DOB db = new DOB(y, m, d);
				if(db.set())
				{
					id = IDGENERATOR.Generate(choice);
					Account debit = new Debit(name, id, db.getDOB(), nominee, balance);
					acccount.Add(debit);

				}
				else
				{
					bool flag = false;
					Console.Clear();
					Console.WriteLine("Enter DOB Again Please:");
					while (flag != true)
					{
						Console.WriteLine("Date of Birth:");

						Console.Write("Day(DD):");
						d = checkException();
						//Console.WriteLine("\n");

						Console.Write("Month(MM):");
						m = checkException();
						//Console.WriteLine("\n");

						Console.Write("Year(YYYY):");
						y = checkException();
						//Console.WriteLine("\n");
						DOB db1 = new DOB(y, m, d);
						if (db1.set())
						{
							id = IDGENERATOR.Generate(choice);
							Account debit = new Debit(name, id, db.getDOB(), nominee, balance);
							acccount.Add(debit);
							flag = true;
						}
					}
				}


			}
			else if(choice == 1)
			{
				Console.Write("Account Name: ");
				name = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.Write("Nominee: ");
				nominee = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.WriteLine("Date of Birth:");

				Console.Write("Day(DD):");
				d = checkException();
				//Console.WriteLine("\n");

				Console.Write("Month(MM):");
				m = checkException();
				//Console.WriteLine("\n");

				Console.Write("Year(YYYY):");
				y = checkException();
				//Console.WriteLine("\n");

				DOB db = new DOB(y, m, d);
				if (db.set())
				{
					id = IDGENERATOR.Generate(choice);
					Account credit = new Credit(name, id, db.getDOB(), nominee, balance);
					acccount.Add(credit);
				}
				else
				{
					bool flag = false;
					Console.Clear();
					Console.WriteLine("Enter DOB Again Please:");
					while (flag != true)
					{
						Console.WriteLine("Date of Birth:");

						Console.Write("Day(DD):");
						d = checkException();
						//Console.WriteLine("\n");

						Console.Write("Month(MM):");
						m = checkException();
						//Console.WriteLine("\n");

						Console.Write("Year(YYYY):");
						y = checkException();
						//Console.WriteLine("\n");
						DOB db1 = new DOB(y, m, d);
						if (db1.set())
						{
							id = IDGENERATOR.Generate(choice);
							Account credit = new Credit(name, id, db.getDOB(), nominee, balance);
							acccount.Add(credit);
							flag = true;
						}
					}
				}
			}
			else if(choice ==2)
			{
				Console.Write("Account Name: ");
				name = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.Write("Nominee: ");
				nominee = Console.ReadLine();
				//Console.WriteLine("\n");

				Console.WriteLine("Date of Birth:");

				Console.Write("Day(DD):");
				d = checkException();
				//Console.WriteLine("\n");

				Console.Write("Month(MM):");
				m = checkException();
				//Console.WriteLine("\n");

				Console.Write("Year(YYYY):");
				y = checkException();
				//Console.WriteLine("\n");

				DOB db = new DOB(y, m, d);
				if (db.set())
				{
					id = IDGENERATOR.Generate(choice);
					Account savings = new Savings(name, id, db.getDOB(), nominee, balance);
					acccount.Add(savings);
				}
				else
				{
					bool flag = false;
					Console.Clear();
					Console.WriteLine("Enter DOB Again Please:");
					while (flag != true)
					{
						Console.WriteLine("Date of Birth:");

						Console.Write("Day(DD):");
						d = checkException();
						//Console.WriteLine("\n");

						Console.Write("Month(MM):");
						m = checkException();
						//Console.WriteLine("\n");

						Console.Write("Year(YYYY):");
						y = checkException();
						//Console.WriteLine("\n");
						DOB db1 = new DOB(y, m, d);
						if (db1.set())
						{
							id = IDGENERATOR.Generate(choice);
							Account savings = new Savings(name, id, db.getDOB(), nominee, balance);
							acccount.Add(savings);
							flag = true;
						}
					}
				}
			}
			else
			{
				create_account();
			}
		}
		public static void deposit(string ID, double amount)
		{
			foreach (Account test in acccount)
			{

				if (ID == test.GetID())
				{
					test.deposit(amount);
					Console.WriteLine("Account deposit Successful");
				}
				else
				{
					Console.WriteLine("Account does not Exist");
				}
			}
		}

		public static void withdraw(string ID, double amount)
		{
			foreach (Account test in acccount)
			{
				if (ID == test.GetID())
				{
					test.withdraw(amount);
					Console.WriteLine("Account withdraw Successful");
				}
				else
				{
					Console.WriteLine("Account does not Exist");
				}
			}
		}

		public static void print(string ID)
		{
			foreach (Account test in acccount)
			{
				//Console.WriteLine("TEST");
				if (ID == test.GetID())
				{
					//Console.WriteLine("TEST");
					test.printAccount();
				}
				else
				{
					Console.WriteLine("Account does not Exist");
				}
			}
		}

		public static void printAllAccount()
		{
			//Console.WriteLine("TEST");
			//Console.WriteLine(test.GetID());
			foreach (Account test in acccount)
			{
				//Console.WriteLine("TEST ACC");
				Console.WriteLine(test.GetID());
			}
		}

		public static void driver()
		{

			bool c = true;
			//Bank bank = new Bank();
			while (c)
			{
				//Console.Clear ();
				Console.WriteLine("****Welcome to Bank Management System  ***");
				Console.WriteLine("What you want to do:");
				Console.WriteLine("0.Create account");
				Console.WriteLine("1.Show account information");
				Console.WriteLine("2.Deposit from account");
				Console.WriteLine("3.Withdraw from account");
				Console.WriteLine("4.Show all account with id");
				Console.WriteLine("5.Clear Screen");
				Console.WriteLine ("6.Exit");
				int choice;
				double setamount;
				string no;
				Console.Write("What do you want to do: ");
				choice = checkException();
				//Console.WriteLine("\n");
				switch (choice)
				{
				case 0:
					create_account();
					break;
				case 1:
					Console.Write("Enter Your Account ID: ");
					no = Console.ReadLine();
					//Console.WriteLine("\n");
					print(no);
					break;
				case 2:
					Console.Write("Enter Your Account ID: ");
					no = Console.ReadLine();
					//Console.WriteLine("\n");
					Console.Write("Enter Your Amount to Deposit: ");
					setamount = Convert.ToDouble(Console.ReadLine());
					//Console.WriteLine("\n");
					deposit(no, setamount);
					break;
				case 3:
					Console.Write("Enter Your Account ID: ");
					no = Console.ReadLine();
					//Console.WriteLine("\n");
					Console.Write("Enter Your Amount to Withdraw: ");
					setamount = Convert.ToDouble(Console.ReadLine());
					//Console.WriteLine("\n");
					withdraw(no, setamount);
					break;
				case 4:
					printAllAccount();
					break;
				case 5:
					Console.Clear ();
					break;
				case 6:
					Console.Clear ();
					return;

				default:
					break;

				}
			}
		}
		static void Main(string[] args)
		{
			driver();
		}
	}
}
