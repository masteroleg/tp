using TraceavitProDesktop.infrastructure;
using EndWorkCompleteViewModel = TraceavitProDesktop.viewModels.end.EndWorkCompleteViewModel;

namespace TraceavitProDesktop.views.operation.end
{
    [TransientService]
    public partial class EndWorkCompleteView 
    {
        public EndWorkCompleteView(EndWorkCompleteViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
