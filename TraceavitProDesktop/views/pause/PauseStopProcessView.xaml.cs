using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.pause;

namespace TraceavitProDesktop.views.operation.pause
{
    [TransientService]
    public partial class PauseStopProcessView 
    {
        public PauseStopProcessView(PauseStopProcessViewModel viewModel )
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
