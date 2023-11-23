using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.start;

namespace TraceavitProDesktop.views.operation.start;

[TransientService]
public partial class LoginView 
{
    public LoginView(LoginViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}