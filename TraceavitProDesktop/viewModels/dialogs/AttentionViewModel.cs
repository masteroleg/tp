using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using MaterialDesignThemes.Wpf;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.dialogs;

[GenerateViewModel, TransientService]
public partial class AttentionViewModel : BaseViewModel
{
    [GenerateProperty] private PackIconKind iconKind;
    [GenerateProperty] private string       message;
    [GenerateProperty] private string       subMessage;
    [GenerateProperty] private string       leftButtonContent;
    [GenerateProperty] private string       rightButtonContent;
    [GenerateProperty] private bool         twoChoiceVisibility;

    public Action<BaseViewModel> NextAction  { get; set; }
    public Action<BaseViewModel> LeftAction  { get; set; }
    public Action<BaseViewModel> RightAction { get; set; }

    public Operations LeftOperation  { get; set; }
    public Operations RightOperation { get; set; }

    public AttentionViewModel(DataBag bag) : base(bag)
    {
        IconKind            = PackIconKind.DeathStar;
        Message             = "Messaga";
        SubMessage          = "SubMessaga";
        TwoChoiceVisibility = false;
    }

    public override DelegateCommand NextCommand => new(async () =>
    {
        await ShowAttention(Attentions.None);
        NextAction?.Invoke(this);
    });

    public override DelegateCommand ChoiceLeftCommand => new(async () =>
    {
        await ShowAttention(Attentions.None);
        LeftAction?.Invoke(this);
    });

    public override DelegateCommand ChoiceRightCommand => new(async () =>
    {
        await ShowAttention(Attentions.None);
        RightAction?.Invoke(this);
    });
}