using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.end;

[TransientService, GenerateViewModel]
public partial class EndWorkConfirmViewModel : BaseViewModel
{
    public EndWorkConfirmViewModel(DataBag bag) : base(bag)
    {
        ChoiceLeftView = Operations.EndWorkComplete;
        ChoiceRightView = Operations.EndWorkCountProduct;
    }
}