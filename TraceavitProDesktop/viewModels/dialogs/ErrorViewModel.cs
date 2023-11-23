using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using MaterialDesignThemes.Wpf;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.dialogs;

[GenerateViewModel, TransientService]
public partial class ErrorViewModel:BaseViewModel
{
    [GenerateProperty] private PackIconKind iconKind;
    [GenerateProperty] private string message;
    [GenerateProperty] private string subMessage;
    [GenerateProperty] private string leftButtonContent;
    [GenerateProperty] private string rightButtonContent;
    [GenerateProperty] private Visibility nextVisibility;


    [GenerateProperty(OnChangedMethod = nameof(VisChange))]
    private Visibility twoChoiceVisibility;

    private void VisChange()
    {
        nextVisibility = Visibility.Collapsed;
    }

    public ErrorViewModel(DataBag bag):base(bag)
    {
        IconKind = PackIconKind.DeathStar;
        Message = "Messaga";
        SubMessage = "SubMessaga";
        nextVisibility = Visibility.Visible;
        twoChoiceVisibility = Visibility.Collapsed;
    }

    public override DelegateCommand NextCommand => new(() =>
    {
        if (NextView == Operations.None)
        {
        }
        _ = ShowError(Errors.None);
    });
}