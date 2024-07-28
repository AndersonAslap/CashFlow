using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseOutputJson Execute(RequestExpenseInputJson input)
    {
        ValidateInput(input);

        var output = new ResponseRegisterExpenseOutputJson();

        return output;
    }

    private void ValidateInput(RequestExpenseInputJson input)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(input);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
