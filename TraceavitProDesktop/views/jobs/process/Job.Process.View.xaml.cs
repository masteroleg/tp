using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.jobs;

namespace TraceavitProDesktop.views.operation.jobs.process;

[TransientService]
public partial class JobProcessView 
{
    public JobProcessView(JobProcessViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}