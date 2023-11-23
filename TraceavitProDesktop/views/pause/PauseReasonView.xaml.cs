using System.Windows.Controls;
using TraceavitProDesktop.viewModels.pause;

namespace TraceavitProDesktop.views.operation.pause
{
    /// <summary>
    /// Логика взаимодействия для PauseReasonView.xaml
    /// </summary>
    public partial class PauseReasonView : UserControl
    {
        public PauseReasonView(PauseReasonViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
