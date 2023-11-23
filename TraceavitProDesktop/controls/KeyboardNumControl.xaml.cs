using System;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;

namespace TraceavitProDesktop.controls
{
    [GenerateViewModel]
    public partial class KeyboardNumControl : UserControl
    {

        [GenerateProperty] private string _InputString;

        public KeyboardNumControl()
        {
            InputString = "";
            DataContext = this;
            InitializeComponent();
        }

        public DelegateCommand<Key> PressKeyCommand => new(value =>
        {
          

            InputString = value switch
            {
                Key.D0     => InputString + "0",
                Key.D1     => InputString + "1",
                Key.D2     => InputString + "2",
                Key.D3     => InputString + "3",
                Key.D4     => InputString + "4",
                Key.D5     => InputString + "5",
                Key.D6     => InputString + "6",
                Key.D7     => InputString + "7",
                Key.D8     => InputString + "8",
                Key.D9     => InputString + "9",
                Key.Delete => InputString.Length > 0 ? InputString[..^1] : "",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
            
            
        });
    }
}