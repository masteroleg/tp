using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.start;

namespace TraceavitProDesktop.views.operation.start;

[TransientService]
public partial class ScanLineView
{
    public ScanLineView(ScanLineViewModel  viewModel )
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}