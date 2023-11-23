using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using MediatR;
using TraceavitProDesktop.backApi.getJobs;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;
using TraceavitProDesktop.services;

namespace TraceavitProDesktop.viewModels.start;

[TransientService,GenerateViewModel]
public partial class CheckWorkspaceViewModel:BaseViewModel
{
    private readonly IMediator mediator;

    public CheckWorkspaceViewModel(DataBag bag,IMediator mediator) : base(bag)
    {
        this.mediator = mediator;
        BackView = Operations.Login;
        NextView = Operations.JobSelect;
    }

    public AsyncCommand CheckedCommand => new( async () =>
    {
        await mediator.Send(new GetJobsCommand());
        NextView = (bag.JobsList.Count, bag.LineState==SetLineResult.NeedRestore) switch
        {
            (0, _)        => Operations.NoJobs,
            ( > 0, false) => Operations.JobSelect,
            ( > 0, true)  => Operations.JobContinue,
            _             => Operations.Login
        };
        await ShowNextView(NextView);
    });

}