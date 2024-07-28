namespace CashFlow.Communication.Responses;
public class ResponseErrorOutputJson
{
    public List<string> Errors { get; set; }

    public ResponseErrorOutputJson(string errorMessage)
    {
        Errors = [errorMessage];
    }

    public ResponseErrorOutputJson(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
