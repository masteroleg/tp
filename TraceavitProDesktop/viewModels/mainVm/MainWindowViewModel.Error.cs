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
    private async Task ErrorView(Errors error)
    {
        await Application.Current.Dispatcher.InvokeAsync(() =>
        {
            var view      = provider.GetRequiredService<ErrorView>();
            var viewModel = view.DataContext as ErrorViewModel?? new (bag);

            switch (error)
            {
                case Errors.None:
                    view= null;
                    break;
                case Errors.AuthAccess:
                    viewModel.IconKind   = PackIconKind.UserBlock;
                    viewModel.Message    = "Помилка авторизації";
                    viewModel.SubMessage = "Будь ласка, зверніться до технічного працівника для вирішення проблеми";
                    break;
                case Errors.BarScanner:
                    viewModel.IconKind   = PackIconKind.LoginVariant;
                    viewModel.Message    = "Упс, проблеми з карткой доступу оператору";
                    viewModel.SubMessage = "Будь ласка, відскануйте код ще раз";
                    break;
                case Errors.CountInFact:
                    viewModel.IconKind            = PackIconKind.ErrorOutline;
                    viewModel.Message             = "Задекларована кількість 5 палет та 15 каністр не збігається з фактичною кількістю";
                    viewModel.SubMessage          = "Перевірте та виправте актуальну кількість або підтвердіть, що наведена кількість вірна";
                    viewModel.TwoChoiceVisibility = Visibility.Visible;

                    viewModel.LeftButtonContent  = "Підтвердити";
                    viewModel.RightButtonContent = "Виправити";

                    break;
                case Errors.Hardware:
                    viewModel.IconKind   = PackIconKind.HammerWrench;
                    viewModel.Message    = "Технічні проблеми з обладнанням";
                    viewModel.SubMessage = "Будь ласка, зупиніть та перевірте обладнання чи зверніться до технічного спеціаліста";
                    break;
                case Errors.Network:
                    viewModel.IconKind   = PackIconKind.Wifi;
                    viewModel.Message    = "Ваше робоче місце не підключене до мережі";
                    viewModel.SubMessage = "Будь ласка, зверніться до технічного працівника для вирішення проблеми";
                    break;
                case Errors.ErrorPrintNoCartridge:
                    viewModel.IconKind   = PackIconKind.PrinterAlert;
                    viewModel.Message    = "Ой, неможливо надрукувати етикетку";
                    viewModel.SubMessage = "Будь ласка, додайте новий катридж у принтер";
                    break;
                case Errors.ErrorPrintNoPaper:
                    viewModel.IconKind   = PackIconKind.PrinterAlert;
                    viewModel.Message    = "Ой, неможливо надрукувати етикетку";
                    viewModel.SubMessage = "Будь ласка, додайте бумагу у принтер";
                    break;
                case Errors.ErrorPrintNoRibbon:
                    viewModel.IconKind   = PackIconKind.PrinterAlert;
                    viewModel.Message    = "Ой, неможливо надрукувати етикетку";
                    viewModel.SubMessage = "Будь ласка, додайте ріббон у принтер";
                    break;
                case Errors.ScanLineNumber:
                    viewModel.IconKind   = PackIconKind.VectorLine;
                    viewModel.Message    = "Упс, проблеми з лінією";
                    viewModel.SubMessage = "Будь ласка, зверніться до технічного працівника для вирішення проблеми";
                    break;

                case Errors.Exception:
                    viewModel.IconKind   = PackIconKind.DeathStar;
                    viewModel.Message    = "Критична помилка";
                    viewModel.SubMessage = bag.Exception?.Message ?? "Unknown error";
                    break;

                case Errors.QRRead:
                    viewModel.IconKind   = PackIconKind.DeathStar;
                    viewModel.Message    = "Критична помилка";
                    viewModel.SubMessage = bag.Exception?.Message ?? "Unknown error";
                    break;

                case Errors.DefectFront :
                    viewModel.IconKind   = PackIconKind.DeathStar;
                    viewModel.Message    = "Критична помилка";
                    viewModel.SubMessage = bag.Exception?.Message ?? "Unknown error";
                    break;

                case Errors.DefectBack:
                    viewModel.IconKind   = PackIconKind.DeathStar;
                    viewModel.Message    = "Критична помилка";
                    viewModel.SubMessage = bag.Exception?.Message ?? "Unknown error";
                    break;

                case Errors.DefectBoth:
                    viewModel.IconKind   = PackIconKind.DeathStar;
                    viewModel.Message    = "Критична помилка";
                    viewModel.SubMessage = bag.Exception?.Message ?? "Unknown error";
                    break;


                default:
                    view= null;
                    break;
            }

            SubContent = view;
        });
    }


    
}