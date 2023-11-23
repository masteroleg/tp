using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.print;

namespace TraceavitProDesktop.views.operation.print
{
    [TransientService]
    public partial class PrintProgressView 
    {
        public PrintProgressView(PrintProgressViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
