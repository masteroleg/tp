using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.end;

[TransientService, GenerateViewModel]
public partial class EndWorkCompleteViewModel : BaseViewModel
{
    public EndWorkCompleteViewModel(DataBag bag) : base(bag)
    {
        Task.Run(Worker);
    }

    private async Task Worker()
    {
        await Task.Delay(bag.Settings.TimeOutViewDialog);
        await ShowNextView(Operations.Login);
    }
}