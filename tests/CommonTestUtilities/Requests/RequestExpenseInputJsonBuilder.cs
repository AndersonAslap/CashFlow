using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestExpenseInputJsonBuilder
{
    public static RequestExpenseInputJson Build()
    {
        return new Faker<RequestExpenseInputJson>()
            .RuleFor(input => input.Title, faker => faker.Commerce.Product())
            .RuleFor(input => input.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(input => input.Date, faker => faker.Date.Past())
            .RuleFor(input => input.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(input => input.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
