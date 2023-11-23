using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.shift;

namespace TraceavitProDesktop.views.operation.shift
{
    [TransientService]
    public partial class ShiftRunView 
    {
        public ShiftRunView(ShiftRunViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
