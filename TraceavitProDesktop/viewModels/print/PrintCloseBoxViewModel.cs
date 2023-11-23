using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.print;

[TransientService, GenerateViewModel]
public partial class PrintCloseBoxViewModel : BaseViewModel
{
    public PrintCloseBoxViewModel( DataBag bag) : base(bag)
    {
    }

    
}

