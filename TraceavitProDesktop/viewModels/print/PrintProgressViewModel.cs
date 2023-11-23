using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.print;

[TransientService,GenerateViewModel]
public partial class PrintProgressViewModel:BaseViewModel
{
    public PrintProgressViewModel( DataBag bag) : base(bag)
    {
    }
}