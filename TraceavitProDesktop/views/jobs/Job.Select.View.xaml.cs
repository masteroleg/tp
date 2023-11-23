using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.jobs;

namespace TraceavitProDesktop.views.operation.jobs
{
    [TransientService]
    public partial class JobSelectView 
    {
        public JobSelectView(JobSelectViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}