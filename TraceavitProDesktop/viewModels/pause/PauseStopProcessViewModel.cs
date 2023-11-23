using System;
using System.Threading.Tasks;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.pause;

[TransientService, GenerateViewModel]
public partial class PauseStopProcessViewModel : BaseViewModel
{
    
    public PauseStopProcessViewModel( DataBag bag) : base(bag)
    {
        Task.Run(Worker);
    }
    private async Task Worker()
    {
        await Task.Delay(bag.Settings.TimeOutViewDialog);
        switch (bag.PauseReason)
        {
            case PauseReasonSelected.None:
                await ShowAttention(Attentions.None);
                break;
            case PauseReasonSelected.CallMaster:
                await ShowAttention(Attentions.CallMaster);
                break;
            case PauseReasonSelected.Dinner:
                await ShowAttention(Attentions.Dinner);
                break;
            case PauseReasonSelected.EquipmentSetup:
                await ShowAttention(Attentions.EquipmentSetup);
                break;
            case PauseReasonSelected.Fault:
                await ShowAttention(Attentions.Fault);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}