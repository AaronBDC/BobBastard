using BankAccountNS;


// source: https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

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
    }
}

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