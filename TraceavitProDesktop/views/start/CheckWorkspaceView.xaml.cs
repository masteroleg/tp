using TraceavitProDesktop.infrastructure;
using CheckWorkspaceViewModel = TraceavitProDesktop.viewModels.start.CheckWorkspaceViewModel;

namespace TraceavitProDesktop.views.operation.start;
[TransientService]
public partial class CheckWorkspaceView 
{
    public CheckWorkspaceView(CheckWorkspaceViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}