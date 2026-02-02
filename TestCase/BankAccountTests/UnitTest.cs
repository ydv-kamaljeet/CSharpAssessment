using NUnit.Framework;
using System;
using BankAccountApp;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000m);
        account.Deposit(500m);

        Assert.That(account.Balance, Is.EqualTo(1500m));
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000m);

        Assert.That(
            Assert.Throws<Exception>(() => account.Deposit(-100m))!.Message,
            Is.EqualTo("Deposit amount cannot be negative")
        );
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000m);
        account.Withdraw(400m);

        Assert.That(account.Balance, Is.EqualTo(600m));
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(300m);

        Assert.That(
            Assert.Throws<Exception>(() => account.Withdraw(500m))!.Message,
            Is.EqualTo("Insufficient funds.")
        );
    }
}
