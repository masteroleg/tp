using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.dialogs;

namespace TraceavitProDesktop.views.dialogs
{
    [TransientService]
    public partial class ErrorView
    {
        public ErrorView(ErrorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}