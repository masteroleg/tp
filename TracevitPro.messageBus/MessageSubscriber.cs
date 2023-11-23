namespace TracevitPro.messageBus;

public class MessageSubscriber : IDisposable
{
    public readonly  BusEndpoint               Target;
    public readonly  Type                      MessageType;
    private readonly Action<MessageSubscriber> action;

    public MessageSubscriber(BusEndpoint target, Type messageType, Action<MessageSubscriber> actionDispose)
    {
        Target      = target;
        MessageType = messageType;
        action      = actionDispose;
    }

    public void Dispose()
    {
        action?.Invoke(this);
    }
}