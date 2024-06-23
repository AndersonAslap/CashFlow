using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpenseInputJson input)
    {
        var usecase = new RegisterExpenseUseCase();
        var output = usecase.Execute(input);

        return Created(string.Empty, output);
    }
}
