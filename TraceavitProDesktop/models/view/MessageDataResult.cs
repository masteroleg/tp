namespace TraceavitProDesktop.models.view;

public class MessageDataResult
{
    public MessageDataResultAction Pressed { get; set; } = MessageDataResultAction.None;
    public object?                 Result  { get; set; }

    public T? GetResult<T>() where T : class
    {
        return Result as T;
    }
}

public enum MessageDataResultAction
{
    None,
    Back,
    Next,
    ChoiceLeft,
    ChoiceRight,
    EndWork,
    Pause,
    PrintTicket,
    PrintPallete,
}