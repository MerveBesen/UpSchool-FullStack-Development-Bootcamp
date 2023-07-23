namespace Domain.Dtos;

public class LogDto
{
    public string Message { get; set; }

    public DateTimeOffset SentOn { get; set; }

    public LogDto(string message)
    {
        Message = message;

        SentOn = DateTimeOffset.Now;
    }
}