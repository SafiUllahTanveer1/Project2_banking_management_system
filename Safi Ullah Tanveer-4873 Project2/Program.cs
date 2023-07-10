using System;
using Safi_Ullah_Tanveer_4873_Project2;

namespace Safi_Ullah_Tanveer_4873_Project2
{

    public class BankAccount
    {
        public string Account_Holder_name;
        public int Account_number;
        public double Balance;

        public BankAccount()
        {
            
        }

        public BankAccount(string person_name, int acc_num, double bal)
        {
            Account_Holder_name = person_name;
            Account_number = acc_num;
            Balance = bal;
        }

        public virtual void Deposit(int deposit)
        {
            
            Balance += deposit;

        }

        public virtual void Withdraw(int amount)

        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }

        }

        public virtual void AccountInfo()
        {

            Console.WriteLine(Account_Holder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(Balance);

        }



    }

    public class SavingsAccount : BankAccount
    {
        public double my_Interest_Rate;
        public int my_time = 0;

        public SavingsAccount(string person_name, int acc_num, int bal, double Interest_Rate, int time) : base(
            person_name, acc_num, bal)
        {
            my_Interest_Rate = Interest_Rate;
            my_time = time;

        }

        public override void Deposit(int deposit)
        {
            // base.Deposit(deposit);
            Console.WriteLine("Amount for deposit is : " + deposit);
            Console.WriteLine("Balance before from account holder "+Account_Holder_name+ " deposit is : " + Balance);
            Balance += deposit * my_Interest_Rate * my_time;
            Console.WriteLine("Balance after from account holder "+Account_Holder_name+ " deposit is : " + Balance);
        }
    }

    public class Checking_Account : BankAccount
    {

        public Checking_Account(string person_name, int acc_num, int bal) : base(person_name, acc_num, bal)
        {

        }

        public override void Withdraw(int amount_to_withdraw)
        {
            if (amount_to_withdraw <= Balance)
            {
                Console.WriteLine("Amount to withdrawn is : " + amount_to_withdraw);
                Console.WriteLine("Balance before from account holder "+Account_Holder_name+ " withdraw is : " + Balance);
                Balance -= amount_to_withdraw;
                Console.WriteLine("Balance after from account holder "+Account_Holder_name+ " withdraw is : " + Balance);
            }
            else
            {
                Console.WriteLine("You don't have sufficient amount");
            }
        }
    }

    public class Bank
    {
        BankAccount account1 = new BankAccount();
        BankAccount account2 = new BankAccount();

        public Bank()
        {
            // internal BankAccount[] account_list = new BankAccount(person_name, acc_num, bal);
        }

        public void set_accouts()
        {
            
            // Console.WriteLine("Enter the value for person ");
            // Console.WriteLine("Enter the name");
            string name = "subhan";
            // Console.WriteLine("Enter the account number : ");
            int acc_num = 1;
            // Console.WriteLine("Enter the Initial Balance in account : ");
            int bal = 1000;
            // Console.WriteLine("Enter the Interest Rate:");
            double interest_rate = 0.1;
            // Console.WriteLine("Enter the time : ");
            int time = 2;
            account1 = new SavingsAccount(name, acc_num, bal, interest_rate, time);


            // Console.WriteLine("Enter the value for person " + (0 + 1));
            // Console.WriteLine("Enter the name");
            string name1 = "safi";
            // Console.WriteLine("Enter the account number : ");
            int acc_num1 = 2;
            // Console.WriteLine("Enter the Initial Balance in account : ");
            int bal1 = 2000;
            account2 = new Checking_Account(name1, acc_num1, bal1);
                

            }
            
        public void deposit(int bal)
        {
            account1.Deposit(bal);
        }

        public void withdraw(int amount)
        {
            account2.Withdraw(amount);
        }
    }

    }

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank1 = new Bank();
        bank1.set_accouts();
        // Console.WriteLine("Enter value to deposit : ");
        int bal = 100;
        bank1.deposit(bal);
        
        // Console.WriteLine("Enter value to withdraw : ");
        int amount = 100;
        bank1.withdraw(amount);
    }
    
}