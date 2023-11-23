using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

[TransientService,GenerateViewModel]
public partial class JobContinueActualCountViewModel : BaseViewModel
{
    public JobContinueActualCountViewModel(DataBag bag) : base(bag)
    {
        BackView = Operations.JobContinue;
        NextView = Operations.ShiftStart;
    }
}


