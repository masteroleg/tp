using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;
using System.Windows;


namespace TracevitPro.messageBus;


public class MessageBus : IAsyncDisposable
{


    private          CancellationTokenSource            _cancel       = new();
    private          BufferBlock<(BusEndpoint, object)> messagesQueue = new();

    private ConcurrentDictionary<MessageSubscriber, Func<object, Task>> msgSubscibers = new();
    private ConcurrentDictionary<MessageSubscriber, Func<object, Task<object>>> reqSubscibers = new();

    private TimeSpan Timeout;
    private Task mSender;

    public static MessageBus Instance { get; } = new();
    private MessageBus()
    {
        Timeout                = TimeSpan.FromMilliseconds(500);
        mSender                = Task.Run(MessageSender, _cancel.Token);
    }

    

    private async Task MessageSender()
    {
        while (!_cancel.Token.IsCancellationRequested)
        {
            try
            {
                var (target, message) = await messagesQueue.ReceiveAsync(_cancel.Token);
                var subscribers =
                    msgSubscibers.Where(s => s.Key.Target == target && s.Key.MessageType == message.GetType()).ToList();
                foreach (var subs in subscribers)
                {
                    var task = subs.Value.Invoke(message);
                    var ct = new CancellationTokenSource(Timeout).Token;

                    await Application.Current.Dispatcher.InvokeAsync( async () =>
                    {
                        await task.WaitAsync(ct);
                    });
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public async Task Send<T>(BusEndpoint endpoint, T message)
    {
        await messagesQueue.SendAsync((endpoint, message)!);
    }

    private void UnSubscribeMessage(string progressEpTarget)
    {
        var (key, _) = msgSubscibers.FirstOrDefault(x => x.Key.Target.Target == progressEpTarget);
        msgSubscibers.Remove(key, out _);
    }

    public IDisposable SubscribeMessage<TIn>(BusEndpoint endpoint, Func<TIn, Task> handler)
    {
        var disposer = new MessageSubscriber(endpoint, typeof(TIn), s => msgSubscibers.TryRemove(s, out _));

        msgSubscibers.TryAdd(disposer, item => handler((TIn)item));
        return disposer;
    }

    public void UnSubscribeAllMessages()
    {
        msgSubscibers.Clear();
    }

    public async ValueTask DisposeAsync()
    {
        _cancel.Cancel();
    }
}