using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.shift;

[TransientService, GenerateViewModel]
public partial class ShiftStartViewModel : BaseViewModel
{
    public ShiftStartViewModel(DataBag bag) : base(bag)
    {
        BackView       = Operations.JobNew;
        NextView = Operations.ShiftRun;
    }

    public AsyncCommand StartServiceShiftCommand => new ( async () =>
    {
        await ShowAttention(Attentions.ServiceShift);
    });


    /*public  async Task Worker()
    {
        switch (result.Pressed)
        {
            case MessageDataResultAction.Back:
                state.NextStep = state.PreviousStep;
                break;
            case MessageDataResultAction.ChoiceLeft:
                state.IsServiceShift = false;
                state.NextStep       = StepName.ShiftRun;
                break;
            case MessageDataResultAction.ChoiceRight:
                var attention = await ShowAttention(Attentions.ServiceShift);
                switch (attention.Pressed)
                {
                    case MessageDataResultAction.ChoiceLeft:
                        state.IsServiceShift = true;
                        state.NextStep       = StepName.ShiftRun;
                        await ShowAttention(Attentions.None);
                        break;
                    case MessageDataResultAction.ChoiceRight:
                        state.IsServiceShift = false;
                        await ShowAttention(Attentions.None);
                        break;
                }
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(result.Pressed));
        }
    }*/
}