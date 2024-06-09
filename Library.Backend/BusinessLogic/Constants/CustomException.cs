namespace Library.Backend.BusinessLogic.Constants;

public class CustomException(string message)
        : Exception
{
    public new string Message { set; get; } = message;
}
