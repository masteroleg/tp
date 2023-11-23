using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.print;

[TransientService, GenerateViewModel]
public partial class PrintActualCountProductViewModel : BaseViewModel
{
    public PrintActualCountProductViewModel( DataBag bag) : base(bag)
    {
    }
}