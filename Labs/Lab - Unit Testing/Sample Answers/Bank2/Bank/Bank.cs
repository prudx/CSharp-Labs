// sample solution to Lab 1 - Unit Testing, Task 1

using System;
using System.Collections;
using System.Collections.Generic;

namespace Bank
{
    // a bank account
    public class BankAccount
    {
        // fields
        private String sortCode;
        private String accountNo;
        private double balance;                 // €
        private double overdraftLimit;          // €  

        private List<double> transactionHistory;    // a record of amounts deposited and withdrawn

        // constructor
        public BankAccount(String sortCode, String accountNo, double overdraftLimit)
        {
            if (overdraftLimit >= 0)
            {
                this.sortCode = sortCode;
                this.accountNo = accountNo;
                this.balance = 0;
                this.overdraftLimit = overdraftLimit;

                transactionHistory = new List<double>();
            }
            else
            {
                throw new ArgumentException("overdraft limit must be >= 0");
            }
           
        }

        // overloaded constructor - chain
        public BankAccount(String sortCode, String accountNo)
            : this(sortCode, accountNo, 0)
        {
        }

        public String SortCode { get { return sortCode; } }
        public String AccountNo { get { return accountNo; } }
        public double Balance { get { return balance; } }
        public double OverdraftLimit { get { return overdraftLimit; } }
        public List<double> TransactionHistory { get { return transactionHistory; } }


        // deposit money in the account
        public void Deposit(double amount)                      // assume amount is positive
        {
            if (amount > 0)
            {
                balance += amount;

                // record in transaction history
                transactionHistory.Add(amount);
            }
            else
            {
                throw new ArgumentException("Amount must be >= 0");
            }
        }

        // withdraw money if there are sufficient funds
        public void Withdraw(double amount)                    
        {
            if (amount > 0)
            {
                if ((balance + overdraftLimit) > amount)
                {
                    balance -= amount;
                    transactionHistory.Add(amount * -1);            // record
                }
                else                                                // insufficient funds
                {
                    throw new ArgumentException("Insufficient funds");
                }
            }
            else
            {
                throw new ArgumentException("Amount must be >= 0");
            }
        }


        // return all details about the account
        public override String ToString()
        {
            String output = "sort code: " + sortCode + " account no: " + accountNo + " overdraft limit: " + overdraftLimit + " balance: " + balance;
            output += "Transaction History:";
            foreach (double trans in transactionHistory)
            {
                output = +trans + " ";
            }
            return output;
        }

    }
}

