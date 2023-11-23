using DevExpress.Mvvm;
using DevExpress.Mvvm.CodeGenerators;
using TraceavitProDesktop.backApi.barScan;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.viewModels.mainVm;

public partial class MainWindowViewModel
{
    //[GenerateProperty] private bool _IsConnected;
    //[GenerateProperty] private bool _IsEquipmentDamaged;
    //[GenerateProperty] private bool _IsWrongAuth;

    [GenerateProperty] private string _server;
    [GenerateProperty] private string _currentView;
    [GenerateProperty] private StationType _stationType;
    [GenerateProperty] private DataBag  _bag;


    #region BarScanner

    public DelegateCommand<string> BarScannerOkCommand => new(val =>
    {
        bag.DevData.BarScannerResultDev = BarScannerResult.Scanned;
        bag.DevData.BarScannerDataDev = val;
    });

    public DelegateCommand<string> BarScannerScanLine => new(val =>
    {
        bag.DevData.BarScannerResultDev = BarScannerResult.Scanned;
        bag.DevData.BarScannerDataDev = val;
    });

    public DelegateCommand BarScannerErrorCommand => new(() =>
    {
        bag.DevData.BarScannerResultDev = BarScannerResult.Scanned;
        bag.DevData.BarScannerDataDev = string.Empty;
    });

    #endregion

    public DelegateCommand<bool> SetTypeCommand => new((chk) =>
    {
        bag.Settings.StationType = chk ? StationType.Labeler : StationType.Packer;
        StationType = bag.Settings.StationType;
    });

    private void DevInit()
    {
        Server = bag.Settings.Server;
        StationType = bag.Settings.StationType;
        Bag = bag;
    }
}