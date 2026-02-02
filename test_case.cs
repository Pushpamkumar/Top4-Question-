using NUnit.Framework;
using System;

[TestFixture] // Required test attribute for the test class
public class UnitTest
{
    [Test] // Test attribute for test method
    public void Test_Deposit_ValidAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Deposit(500m);

        // Assert (only one assert as required)
        Assert.AreEqual(1500m, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act & Assert
        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-200m)).Message
        );
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Withdraw(300m);

        // Assert
        Assert.AreEqual(700m, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange
        Program account = new Program(500m);

        // Act & Assert
        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(800m)).Message
        );
    }
}
