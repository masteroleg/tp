using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

public class JobContinueViewModel : BaseViewModel
{
    public JobContinueViewModel(DataBag bag) : base(bag)
    {
        BackView        = Operations.CheckWorkspace;
        ChoiceLeftView  = Operations.JobContinueActualCount;
        ChoiceRightView = Operations.JobSelect;
    }
}