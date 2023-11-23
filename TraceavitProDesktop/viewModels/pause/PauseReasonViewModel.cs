using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.pause;

[TransientService,GenerateViewModel]
public partial class PauseReasonViewModel:BaseViewModel
{

    [GenerateProperty] private PauseReasonSelected _reasonSelected;



    public PauseReasonViewModel( DataBag bag) : base(bag)
    {
        ReasonSelected = PauseReasonSelected.None;
        NextView       = Operations.PauseProcess;
    }

    public DelegateCommand<PauseReasonSelected> SelectReasonCommand => new(reasone =>
    {
        ReasonSelected = reasone;
        bag.PauseReason = reasone;
    });
}