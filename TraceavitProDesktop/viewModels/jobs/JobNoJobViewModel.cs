using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.jobs;

[TransientService,GenerateViewModel]
public partial class JobNoJobViewModel:BaseViewModel
{
    public JobNoJobViewModel(DataBag bag) : base(bag)
    {
    }
}