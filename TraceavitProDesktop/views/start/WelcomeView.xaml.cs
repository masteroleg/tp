using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.start;

namespace TraceavitProDesktop.views.operation.start;

[TransientService]
public partial class WelcomeView
{
    public WelcomeView(WelcomeViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}