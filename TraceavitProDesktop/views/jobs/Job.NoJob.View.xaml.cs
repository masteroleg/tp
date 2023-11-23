using TraceavitProDesktop.infrastructure;
using JobNoJobViewModel = TraceavitProDesktop.viewModels.jobs.JobNoJobViewModel;

namespace TraceavitProDesktop.views.operation.jobs;

[TransientService]
public partial class JobNoJobView
{
    public JobNoJobView(JobNoJobViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}