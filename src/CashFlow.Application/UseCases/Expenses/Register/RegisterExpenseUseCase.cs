using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseOutputJson Execute(RequestExpenseInputJson input)
    {
        var output = new ResponseRegisterExpenseOutputJson();

        return output;
    }
}
