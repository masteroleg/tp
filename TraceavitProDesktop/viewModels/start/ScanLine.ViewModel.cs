using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using MediatR;
using TraceavitProDesktop.backApi.barScan;
using TraceavitProDesktop.backApi.barScannerDevice;
using TraceavitProDesktop.backApi.setLine;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;
using TraceavitProDesktop.services;

namespace TraceavitProDesktop.viewModels.start;

[TransientService,GenerateViewModel]
public partial class ScanLineViewModel:BaseViewModel
{
    private readonly IMediator mediator;

    public ScanLineViewModel(DataBag bag,IMediator mediator) : base(bag)
    {
        this.mediator = mediator;
        BackView        = Operations.Login;
    }

    protected override async Task Worker()
    {
        while (!token.IsCancellationRequested)
        {
            if (await  mediator.Send(new InitDeviceCommand())== false)
            {
                await ShowError(Errors.BarScannerNoDevice);
                continue;
            }

            var (barCode, barScanResult) = await mediator.Send(new BarScanCommand());

            if (barScanResult == BarScannerResult.ScanError)
            {
                await ShowError(Errors.BarScanner);
                continue;
            }

            var lineNumberResult = await  mediator.Send(new SetLineCommand(barCode)) ;

            if (lineNumberResult == SetLineResult.Success)
            {
                break;
            }
            await ShowError(Errors.ScanLineNumber);
        }

        await ShowNextView(Operations.CheckWorkspace);
    }
}