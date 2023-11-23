using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using MediatR;
using TraceavitProDesktop.backApi.barScan;
using TraceavitProDesktop.backApi.barScannerDevice;
using TraceavitProDesktop.backApi.login;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.start;

[TransientService, GenerateViewModel]
public partial class LoginViewModel : BaseViewModel
{
    private readonly IMediator mediator;

    public LoginViewModel(DataBag bag, IMediator mediator) : base(bag)
    {
        this.mediator = mediator;
    }

    [GenerateProperty] private string _SearchKeyword;

    protected override async Task Worker()
    {
        while (!token.IsCancellationRequested)
        {
            if (await mediator.Send(new InitDeviceCommand()) == false)
            {
                await ShowError(Errors.BarScannerNoDevice);
                continue;
            }

            var (barCode, barScanResult) = await mediator.Send(new BarScanCommand());

            if (barScanResult is BarScannerResult.ScanError or BarScannerResult.Cancelation)
            {
                await ShowError(Errors.BarScanner);
                continue;
            }

            var exception = await mediator.Send(new LoginCommand(barCode));
            if (exception != LoginCommandResult.Success)
            {
                await ShowError(Errors.AuthAccess);
                continue;
            }

            break;
        }

        await ShowNextView(Operations.Welcome);
    }
}