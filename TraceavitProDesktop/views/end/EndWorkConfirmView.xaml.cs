using System.Windows.Controls;
using TraceavitProDesktop.viewModels.end;

namespace TraceavitProDesktop.views.operation.end;

public partial class EndWorkConfirmView : UserControl
{
    public EndWorkConfirmView(EndWorkConfirmViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}