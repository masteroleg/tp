using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using MediatR;
using TraceavitProDesktop.backApi.checkHardware;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.shift;

[TransientService, GenerateViewModel]
public partial class ShiftRunViewModel : BaseViewModel
{
    private readonly IMediator mediator;

    public ShiftRunViewModel( DataBag bag,IMediator mediator) : base(bag)
    {
        this.mediator = mediator;
        NextView        = Operations.JobProcess;
        workerComplete  = false;
    }

    protected override async Task Worker()
    {
        while (!token.IsCancellationRequested)
        {
            if (!await mediator.Send(new CheckHardwareCommand()))
            {
                await ShowError(Errors.HardwareError);
                continue;
            }

            break;
        }

        await Task.Delay(bag.Settings.TimeOutViewDialog);
        workerComplete = true;
        await ShowNextView(Operations.JobProcess);
    }
}