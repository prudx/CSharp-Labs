using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        int SortCode { get; }
        int AccountNum { get; }
        private double overdraftLimit;
        private double balance;
        public List<double> transactionHistory;

        public double OverdraftLimit
        {
            get
            {
                return overdraftLimit;
            }
        }
        public double Balance               
        {
            get                             
            {
                return balance;
            }
        }

        public BankAccount (int sc, int an)
        {
            SortCode = sc;
            AccountNum = an;
            overdraftLimit = 0;
            balance = 0;
            transactionHistory = new List<double>();
        }

        public void Deposit(double depositAmt)
        {
            balance += depositAmt;
            transactionHistory.Add(depositAmt);
        }

        public void Withdraw(double withdrawAmt)
        {
            try
            {
                if (Balance > withdrawAmt)
                {
                    balance -= withdrawAmt;
                    transactionHistory.Add(withdrawAmt);
                }
                else if ((OverdraftLimit + Balance) > withdrawAmt)
                {
                    balance -= withdrawAmt;
                    transactionHistory.Add(withdrawAmt);
                }
            }
            catch
            {
                throw new Exception("Invalid funds");
            }
        }

        public override string ToString()
        {
            return "\nBank account number: "+AccountNum
                +"Sort Code: "+SortCode
                +"Overdraft Limit: "+OverdraftLimit
                +"Balance: "+Balance
                +"Transaction history: \n"+transactionHistory;

        }

        public static void Main()
        {

        }
    }
}
