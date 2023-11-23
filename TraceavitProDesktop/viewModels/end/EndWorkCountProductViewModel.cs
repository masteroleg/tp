using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.end;

[TransientService, GenerateViewModel]
public partial class EndWorkCountProductViewModel : BaseViewModel
{
    public EndWorkCountProductViewModel(DataBag bag) : base(bag)
    {
        NextView = Operations.EndWorkConfirmError;
    }
}