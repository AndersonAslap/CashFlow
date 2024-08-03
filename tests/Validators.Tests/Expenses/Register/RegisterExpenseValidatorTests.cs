using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact(DisplayName = nameof(Success))]
    [Trait("Validators", "Expense Register - Validator")]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var input = RequestExpenseInputJsonBuilder.Build();

        //Act
        var result = validator.Validate(input);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory(DisplayName = nameof(ErrorWhenTitleIsInvalid))]
    [Trait("Validators", "Expense Register - Validator")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("    ")]
    public void ErrorWhenTitleIsInvalid(string? title)
    {
        var validator = new RegisterExpenseValidator();
        var input = RequestExpenseInputJsonBuilder.Build();
        input.Title = title;

        var result = validator.Validate(input);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact(DisplayName = nameof(ErrorWhenDateFuture))]
    [Trait("Validators", "Expense Register - Validator")]
    public void ErrorWhenDateFuture()
    {
        var validator = new RegisterExpenseValidator();
        var input = RequestExpenseInputJsonBuilder.Build();
        input.Date = DateTime.UtcNow.AddDays(1);

        var result = validator.Validate(input);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE));
    }

    [Fact(DisplayName = nameof(ErrorWhenPaymentTypeIsInvalid))]
    [Trait("Validators", "Expense Register - Validator")]
    public void ErrorWhenPaymentTypeIsInvalid()
    {
        var validator = new RegisterExpenseValidator();
        var input = RequestExpenseInputJsonBuilder.Build();
        input.PaymentType = (PaymentType)100;

        var result = validator.Validate(input);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
    }

    [Theory(DisplayName = nameof(ErrorWhenAmountIsInvalid))]
    [Trait("Validators", "Expense Register - Validator")]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    public void ErrorWhenAmountIsInvalid(decimal amount)
    {
        var validator = new RegisterExpenseValidator();
        var input = RequestExpenseInputJsonBuilder.Build();
        input.Amount = amount;

        var result = validator.Validate(input);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
}
