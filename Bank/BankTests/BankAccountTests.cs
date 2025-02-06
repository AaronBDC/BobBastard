using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public sealed class BankAccountTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            #region v0: act and assert
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            #endregion v0: act and assert

            #region v1: try and catch (act and assert)
            //// Arrange
            //double beginningBalance = 11.99;
            //double debitAmount = 20.0;
            //BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //// ACT
            //try
            //{
            //    // code for try
            //    account.Debit(debitAmount);
            //}
            //catch (System.ArgumentOutOfRangeException e)
            //{
            //    // code for catch
            //    StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            //}
            //finally
            //{
            //    // code for finally/cleanup
            //}
            #endregion v1: try and catch (act and assert)

            #region v2: try and catch (act and assert) and assert.fail 
            //// Arrange
            //double beginningBalance = 11.99;
            //double debitAmount = 20.0;
            //BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //// ACT
            //try
            //{
            //    // code for try
            //    account.Debit(debitAmount);
            //}
            //catch (System.ArgumentOutOfRangeException e)
            //{
            //    // code for catch
            //    StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            //    return;
            //}
            //finally
            //{
            //    // code for finally/cleanup
            //}
            //Assert.Fail("The expected exception was not thrown.");
            #endregion v2: try and catch (act and assert) and assert.fail 
        }
    }
}

#region LessonsLearned_About_TestTools.UnitTesting

// source: https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

// pre-requisite: add the other Project "Bank" to this project as a reference

//////// example copied below:
//////// The 'using' statement for Test Tools is in GlobalUsings.cs
//////// using Microsoft.VisualStudio.TestTools.UnitTesting;

//////namespace BankTests
//////{
//////    [TestClass]
//////    public class BankAccountTests
//////    {
//////        [TestMethod]
//////        public void TestMethod1()
//////        {
//////        }
//////    }
//////}

// additional info:
// ## Assertions from Assert Class: https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-3.7

#endregion region LessonsLearned_About_TestTools.UnitTesting