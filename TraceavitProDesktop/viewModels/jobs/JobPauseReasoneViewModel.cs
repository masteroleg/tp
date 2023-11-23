using TraceavitProDesktop.models;
using TraceavitProDesktop.models.view;

namespace TraceavitProDesktop.viewModels.jobs;

public class JobPauseReasoneViewModel:BaseViewModel
{
    public JobPauseReasoneViewModel(DataBag bag) : base(bag)
    {
        BackView = Operations.JobProcess;
    }





    /*public  async Task Worker()
    {

        var result = await ShowView(Operations.PauseReasonView);
        switch (result.Pressed)
        {
            case MessageDataResultAction.Back:
                state.NextStep = StepName.JobProcess;
                return;
            case MessageDataResultAction.Next:

                break;
        }

        var reasone = (PauseReasoneResult)(result.Result ?? PauseReasoneResult.None);
        result = await ShowView(Operations.PauseProcess, data: reasone, action: async data =>
        {
            await Task.Delay(bag.TimeOutViewDialog);
            data.Result.TrySetResult(new MessageDataResult { Result = reasone });
        });


        reasone = (PauseReasoneResult)(result.Result ?? PauseReasoneResult.None);
        switch (reasone)
        {
            case PauseReasoneResult.None:
                //exception
                break;
            case PauseReasoneResult.CallMaster:
                await ShowAttention(Attentions.CallMaster);
                break;
            case PauseReasoneResult.Dinner:
                await ShowAttention(Attentions.Dinner);
                break;
            case PauseReasoneResult.EquipmentSetup:
                await ShowAttention(Attentions.EquipmentSetup);
                break;
            case PauseReasoneResult.Fault:
                await ShowAttention(Attentions.Fault);
                break;
        }

        state.NextStep = StepName.JobProcess;
    }*/

}