//////// See https://aka.ms/new-console-template for more information
//////Console.WriteLine("Hello, World!");
using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        private bool m_balling;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
            //m_balling = GettingPaid(balance); //old
            m_balling = false; //new
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        public bool Balling
        {
            get { return m_balling; }
        }
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                //throw new ArgumentOutOfRangeException("amount"); //old-works
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage); //new-works
            }

            if (amount < 0)
            {
                //throw new ArgumentOutOfRangeException("amount"); //old-works
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage); //new-works
            }

            //m_balance += amount; // intentionally incorrect code -- original (old)
            m_balance -= amount; // intentionally incorrect code --  (new) works

        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            #region @COMEBACK
            /// @COMEBACK Remember this mistake ! - a few lines above in the Debit fx I was supposed to modify that line.
            /// thats why my tests were broken and throwing this error below: SUCCESS!
            /// 
            ///
            //////Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException
            //////  HResult=0x80131500
            //////  Message=Assert.AreEqual failed. Expected a difference no greater than <0.001> between expected value <7.44> and actual value <16.54>. Account not debited correctly
            //////  Source=Microsoft.VisualStudio.TestPlatform.TestFramework
            //////  StackTrace:
            //////   at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowAssertFailed(String assertionName, String message)
            //////   at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Double expected, Double actual, Double delta, String message, Object[] parameters)
            //////   at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(Double expected, Double actual, Double delta, String message)
            //////   at BankTests.BankAccountTests.Debit_WithValidAmount_UpdatesBalance() in C:\Users\nikkita\source\repos\Bank\BankTests\BankAccountTests.cs:line 28
            //////   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
            //////   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)

            ///
            //m_balance += amount; //old -- fails test
            //m_balance -= amount; //new--fails: see above
            #endregion @COMEBACK

            m_balance += amount; //redid original for @lessons_learned: m_balance += amount;


        }

        public bool GettingPaid(double amount)
        {
            bool result = false;
            try
            {
                // code for try
                if (amount > 100.00)
                {
                    result = true;
                    Console.WriteLine("Are you gettin paid? {0}", result);
                }
                m_balling = result;
            }
            catch (Exception ex)
            {
                // code for catch
            }
            finally
            {
                // code for finally/cleanup
            }

            return result;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}