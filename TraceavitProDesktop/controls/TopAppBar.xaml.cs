using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace TraceavitProDesktop.controls
{
    /// <summary>
    /// Логика взаимодействия для TopAppBar.xaml
    /// </summary>
    public partial class TopAppBar 
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TopAppBar), new PropertyMetadata(default(string)));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => 
                SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command), typeof(ICommand), typeof(TopAppBar), new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public DelegateCommand BackCmd => new DelegateCommand(() =>
        {
            Command?.Execute(null);
        });
        
        
        
        

        public TopAppBar()
        {
            InitializeComponent();
        }
    }
}
