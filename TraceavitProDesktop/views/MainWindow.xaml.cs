using System.Windows;
using TraceavitProDesktop.infrastructure;
using MainWindowViewModel = TraceavitProDesktop.viewModels.mainVm.MainWindowViewModel;

namespace TraceavitProDesktop.views;

[SingletonService]
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }

    private void LogRichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        LogRichTextBox.ScrollToEnd();
    }
}