using System;
using DevExpress.Mvvm.CodeGenerators;
using MediatR;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.mainVm;

[SingletonService, GenerateViewModel]
public partial class MainWindowViewModel : BaseViewModel
{
    // private readonly ConnectionService connection;
    private readonly IMediator mediator;
    private readonly IServiceProvider provider;

    


    //[GenerateProperty] private int clientId;
    [GenerateProperty] private object? content;
    [GenerateProperty] private object? subContent;
    [GenerateProperty] private object exceptionContent;

    public MainWindowViewModel( DataBag bag, IMediator mediator,
        IServiceProvider provider) : base(bag)
    {
        this.mediator = mediator;
        this.provider = provider;

        DevInit();

        mBus.SubscribeMessage<Operations>(Endpoints.View, OperationView);
        mBus.SubscribeMessage<Errors>(Endpoints.View, ErrorView);
        mBus.SubscribeMessage<Attentions>(Endpoints.View, AttentionView);
        _ = OperationView(Operations.Login);
    }
}