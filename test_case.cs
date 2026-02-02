using NUnit.Framework;
using System;

/// <summary>
/// Contains unit test cases for validating
/// deposit and withdrawal operations of a bank account.
/// </summary>
[TestFixture]
public class UnitTest
{
    /// <summary>
    /// Verifies that depositing a valid amount
    /// correctly increases the account balance.
    /// </summary>
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000m);

        account.Deposit(500m);

        Assert.AreEqual(1500m, account.Balance);
    }

    /// <summary>
    /// Verifies that depositing a negative amount
    /// throws an exception with the expected error message.
    /// </summary>
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000m);

        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-200m)).Message
        );
    }

    /// <summary>
    /// Verifies that withdrawing a valid amount
    /// correctly reduces the account balance.
    /// </summary>
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000m);

        account.Withdraw(300m);

        Assert.AreEqual(700m, account.Balance);
    }

    /// <summary>
    /// Verifies that attempting to withdraw an amount
    /// greater than the available balance throws an exception.
    /// </summary>
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500m);

        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(800m)).Message
        );
    }
}
