using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.jobs;

namespace TraceavitProDesktop.views.operation.jobs
{
    [TransientService]
    public partial class JobNewView
    {
        public JobNewView(JobNewViewModel viewModel)
        {
            
            DataContext  = viewModel;
            InitializeComponent();
        }
    }
}
