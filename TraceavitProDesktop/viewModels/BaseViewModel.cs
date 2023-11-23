using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;
using TracevitPro.messageBus;

namespace TraceavitProDesktop.viewModels;

public abstract class BaseViewModel
{
    protected DataBag    bag;
    protected MessageBus mBus;

    protected Operations BackView;
    protected Operations NextView;
    protected Operations ChoiceLeftView;
    protected Operations ChoiceRightView;

    protected bool workerComplete;
    
    private   CancellationTokenSource cancellationTokenSource = new();
    protected CancellationToken       token;

    protected BaseViewModel( DataBag bag)
    {
        mBus      = MessageBus.Instance;
        this.bag       = bag;
        workerComplete = false;
        token =cancellationTokenSource.Token;
        RunWorker();
    }

    private void RunWorker()
    {
        Task.Run( async ()=>
        {
            await Worker();
            workerComplete = true;
        }, token);
    }

    protected virtual Task Worker()
    {
        return Task.CompletedTask;
    }

    public DelegateCommand BackCommand => new(() =>
    {
        cancellationTokenSource.Cancel();
        _ = ShowNextView(BackView);
    });

    public virtual DelegateCommand NextCommand => new(() =>
    {
        cancellationTokenSource.Cancel();
        _ = ShowNextView(NextView);
    }, workerComplete);

    public virtual DelegateCommand ChoiceLeftCommand => new(() =>
    {
        cancellationTokenSource.Cancel();
        _ = ShowNextView(ChoiceLeftView);
    });

    public virtual DelegateCommand ChoiceRightCommand => new(() =>
    {
        cancellationTokenSource.Cancel();
        _ = ShowNextView(ChoiceRightView);
    });

    protected async Task ShowNextView(Operations operationViews)
    {
        await mBus.Send(Endpoints.View, operationViews);
    }

    protected async Task ShowError(Errors errorViews)
    {
        await mBus.Send(Endpoints.View, errorViews);
    }

    protected async Task ShowAttention(Attentions attentionsViews)
    {
        await mBus.Send(Endpoints.View, attentionsViews);
    }

    
}