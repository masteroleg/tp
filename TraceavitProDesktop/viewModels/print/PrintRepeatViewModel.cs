using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.print;

[TransientService, GenerateViewModel]
public partial class PrintRepeatViewModel : BaseViewModel
{
    public PrintRepeatViewModel( DataBag bag) : base(bag)
    {
        SearchKeyword = "#23";
    }


    [GenerateProperty] public string _SearchKeyword;
}

  
    