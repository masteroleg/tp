using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.jobs;

namespace TraceavitProDesktop.views.operation.jobs
{
    [TransientService]
    public partial class JobContinueActualCountView 
    {
        public JobContinueActualCountView(JobContinueActualCountViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
