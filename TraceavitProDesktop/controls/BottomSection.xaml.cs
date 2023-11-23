using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace TraceavitProDesktop.controls
{
    [ContentProperty(nameof(SectionContent))]
    public partial class BottomSection : UserControl
    {
        public static readonly DependencyProperty SectionContentProperty = DependencyProperty.Register(
            nameof(SectionContent), typeof(UIElementCollection), typeof(BottomSection), new PropertyMetadata(default(UIElementCollection)));

        public UIElementCollection SectionContent
        {
            get => (UIElementCollection)GetValue(SectionContentProperty);
            set => SetValue(SectionContentProperty, value);
        }

        public BottomSection()
        {
            InitializeComponent();
            SectionContent = spSectionContent.Children;
        }
    }
}
