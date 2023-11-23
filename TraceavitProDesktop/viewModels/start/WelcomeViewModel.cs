using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.start;

[TransientService, GenerateViewModel]
public partial class WelcomeViewModel : BaseViewModel
{
    [GenerateProperty] private string userName;

    public WelcomeViewModel( DataBag bag) : base(bag)
    {
        UserName = $"{bag?.User?.Name} {bag?.User?.Surname}";
    }

    protected override async Task Worker()
    {
        await Task.Delay(bag.Settings.TimeOutViewDialog, token);
        await ShowNextView(Operations.ScanLine);
    }
}