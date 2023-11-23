using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.shift;

namespace TraceavitProDesktop.views.operation.shift
{
    [TransientService]
    public partial class ShiftStartView 
    {
        public ShiftStartView(ShiftStartViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
