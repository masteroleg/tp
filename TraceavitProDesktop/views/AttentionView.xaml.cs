using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.viewModels.dialogs;

namespace TraceavitProDesktop.views.dialogs;

[TransientService]
public partial class AttentionView 
{
    public AttentionView(AttentionViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}