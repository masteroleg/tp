using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TraceavitProDesktop.models.view;
using TraceavitProDesktop.views.operation;
using TraceavitProDesktop.views.operation.end;
using TraceavitProDesktop.views.operation.jobs;
using TraceavitProDesktop.views.operation.jobs.process;
using TraceavitProDesktop.views.operation.pause;
using TraceavitProDesktop.views.operation.shift;
using TraceavitProDesktop.views.operation.start;

namespace TraceavitProDesktop.viewModels.mainVm;

public partial class MainWindowViewModel
{
   

    private async Task OperationView(Operations operation)
    {
        Application.Current.Dispatcher.InvokeAsync(() =>
        {
            try
            {
                UserControl? view = null;

                view = operation switch
                {
                    Operations.Login                  => provider.GetRequiredService<LoginView>(),
                    Operations.Welcome                => provider.GetRequiredService<WelcomeView>(),
                    Operations.ScanLine               => provider.GetRequiredService<ScanLineView>(),
                    Operations.CheckWorkspace         => provider.GetRequiredService<CheckWorkspaceView>(),
                    Operations.NoJobs                 => provider.GetRequiredService<JobNoJobView>(),
                    Operations.JobSelect              => provider.GetRequiredService<JobSelectView>(),
                    Operations.JobNew                 => provider.GetRequiredService<JobNewView>(),
                    Operations.ShiftStart             => provider.GetRequiredService<ShiftStartView>(),
                    Operations.ShiftRun               => provider.GetRequiredService<ShiftRunView>(),
                    Operations.JobContinueActualCount => provider.GetRequiredService<JobContinueActualCountView>(),
                    Operations.JobProcess             => provider.GetRequiredService<JobProcessView>(),
                    Operations.PauseReason            => provider.GetRequiredService<PauseReasonView>(),
                    Operations.PauseProcess           => provider.GetRequiredService<PauseStopProcessView>(),
                    Operations.EndWorkConfirm         => provider.GetRequiredService<EndWorkConfirmView>(),
                    Operations.EndWorkComplete        => provider.GetRequiredService<EndWorkCompleteView>(),
                    Operations.EndWorkConfirmError    => provider.GetRequiredService<EndWorkConfirmErrorView>(),
                    Operations.EndWorkCountProduct    => provider.GetRequiredService<EndWorkCountProductView>(),
                    Operations.Synchronization        => provider.GetRequiredService<Synchronization>(),

                    _ => null
                };

                /*------*/
                CurrentView = view?.GetType().Name ?? string.Empty;
                Bag = null;
                Bag = bag;
                /*------*/

                Content = view;
                Log.Information("Set View: [{CurrentView}]", CurrentView);
            }
            catch (Exception e)
            {
                Log.Error(e, "OperationView:{}",operation);
            }
        });
    }
}