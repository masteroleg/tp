using System.Windows.Controls;
using TraceavitProDesktop.viewModels.end;

namespace TraceavitProDesktop.views.operation.end
{
    /// <summary>
    /// Логика взаимодействия для EndWorkCountProductView.xaml
    /// </summary>
    public partial class EndWorkCountProductView : UserControl
    {
        public EndWorkCountProductView(EndWorkCountProductViewModel viewModel )
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
