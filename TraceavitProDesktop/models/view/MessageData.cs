using System;
using System.Threading.Tasks;

namespace TraceavitProDesktop.models.view;

public class MessageData
{
    public Guid    Id         { get; set; } = Guid.NewGuid();
    public object? Data       { get; set; } = null;
    public Action<MessageData>? TaskAction { get; set; } = null;

    public TaskCompletionSource<MessageDataResult> Result { get; set; } = new();

    public T? As<T>() where T : class
    {
        return Data as T;
    }
}