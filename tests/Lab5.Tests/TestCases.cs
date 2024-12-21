using Application.Abstractions;
using Application.Accounts;
using Application.ResultTypes;
using Application.Services;
using Application.ValueObjects;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class TestCases
{
    [Theory]
    [InlineData(119.0, typeof(WithdrawingResult.Success))]
    [InlineData(120.0, typeof(WithdrawingResult.NotEnoughMoney))]
    public static void Test_Withdrawn_Situation_InsufficientFunds_And_SufficientFunds_Assert_Unsuccessful_Then_Success(
        double balance,
        Type expectedResult)
    {
        var mockRepository = new Mock<IAccountRepository>();
        mockRepository.Setup(repository => repository.GetById(2))
            .Returns(new GetAccountResult.Success(new BankAccount(new Id(2), new PinCode(1234), new Money(119.0))));

        var mockOperationRepository = new Mock<ITransactionsRepository>();

        var accountService = new AccountService(
            mockRepository.Object,
            mockOperationRepository.Object);

        GetAccountResult gettingResult = mockRepository.Object.GetById(2);

        if (gettingResult is GetAccountResult.Success bankAccount)
        {
            WithdrawingResult operationResult = accountService.Withdraw(
                bankAccount.Account,
                new Money(balance));

            Assert.Equal(expectedResult, expectedResult);
        }
    }

    [Fact]
    public static void Test_Depositing_Account_Assert_Success()
    {
        var mockAccountRepository = new Mock<IAccountRepository>();
        mockAccountRepository
            .Setup(repository => repository.GetById(2))
            .Returns(new GetAccountResult.Success(
                new BankAccount(new Id(2), new PinCode(1234), new Money(0))));

        var mockTransactionRepository = new Mock<ITransactionsRepository>();

        var accountService = new AccountService(
            mockAccountRepository.Object,
            mockTransactionRepository.Object);

        GetAccountResult getResult = mockAccountRepository.Object.GetById(2);

        BankAccount? bankAccount = null;
        if (getResult is GetAccountResult.Success successResult)
        {
            bankAccount = successResult.Account as BankAccount;
        }

        Assert.NotNull(bankAccount);

        accountService.Deposit(bankAccount, new Money(124));

        mockAccountRepository.Verify(
            repository => repository.UpdateMoney(
                It.Is<int>(id => id == 2),
                It.Is<double>(money => money == 124.0)),
            Times.Once);
    }
}