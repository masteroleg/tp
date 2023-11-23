using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using TraceavitProDesktop.models.view;
using TraceavitProDesktop.viewModels.dialogs;
using TraceavitProDesktop.views.dialogs;

namespace TraceavitProDesktop.viewModels.mainVm;

public partial class MainWindowViewModel 
{

    private async Task AttentionView(Attentions attention)
    {
        await Application.Current.Dispatcher.InvokeAsync(() =>
        {
            var view      = provider.GetRequiredService<AttentionView>();
            var viewModel = view.DataContext as AttentionViewModel;


            switch (attention)
            {
                case Attentions.None:
                    view= null;
                    break;
                case Attentions.CallMaster:
                    viewModel.IconKind   = PackIconKind.BellRingOutline;
                    viewModel.Message    = "Виклик майстра";
                    viewModel.SubMessage = "Майстер вже отримав повідомлення і скоро підійде до вашої робочої станції. Будь ласка, залишайтесь поруч і перейдіть на початок роботи";
                    viewModel.NextAction = async model => await ShowNextView(Operations.ShiftRun);
                    break;
                case Attentions.Dinner:
                    viewModel.IconKind   = PackIconKind.SilverwareForkKnife;
                    viewModel.Message    = "Триває перерва";
                    viewModel.SubMessage = "Роботу призупинено.\r Чекаю на вас, щоб продовжити творити!";
                    viewModel.NextAction = async model => await ShowNextView(Operations.ShiftRun);
                    break;
                case Attentions.EquipmentSetup:
                    viewModel.IconKind   = PackIconKind.AlertOutline;
                    viewModel.Message    = "Налагодження обладнання";
                    viewModel.SubMessage = "Будь ласка, покликайте технічного спеціаліста та завершіть зміну. Проводити налаштування самостійно не рекомендується";
                    viewModel.NextAction = async model => await ShowNextView(Operations.ShiftRun);
                    break;
                case Attentions.Fault:
                    viewModel.IconKind   = PackIconKind.HammerWrench;
                    viewModel.Message    = "Несправність";
                    viewModel.SubMessage = "Будь ласка, покликайте технічного спеціаліста та завершіть зміну. Проводити налаштування самостійно не рекомендується";
                    viewModel.NextAction = async model => await ShowNextView(Operations.ShiftRun);
                    break;
                case Attentions.ScanTicket:
                    viewModel.IconKind            = PackIconKind.BarcodeScan;
                    viewModel.Message             = "Проскануйте етикетку";
                    viewModel.SubMessage          = "Будь ласка, наведіть сканер на етикетку";
                    viewModel.TwoChoiceVisibility = false;
                    viewModel.LeftButtonContent   = "Надрукувати знову";
                    viewModel.RightButtonContent  = "На головну";

                    break;
                case Attentions.ServiceShift:
                    viewModel.IconKind            = PackIconKind.HammerWrench;
                    viewModel.Message             = "Точно почати налагоджувальну зміну?";
                    viewModel.SubMessage          = "Зверніть увагу, що при налагоджувальній зміні всі зроблені продукти не будуть зараховуватись у статистику";
                    viewModel.TwoChoiceVisibility = true;
                    viewModel.LeftButtonContent   = "Всеодно почати";
                    viewModel.RightButtonContent  = "Не починати";
                    viewModel.LeftAction = async model =>
                    {
                        bag.IsServiceShift = true;
                        await ShowNextView(Operations.ShiftRun);
                    };

                    break;
                default:
                    view = null;
                    break;
            }

            SubContent = view;
        });
    }

}