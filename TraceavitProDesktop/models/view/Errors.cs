namespace TraceavitProDesktop.models.view;

public enum Errors
{
    None =0, 
    
    AuthAccess,

    BarScanner,//ошибка сканирования
    BarScannerNoDevice,

    CountInFact,
    Hardware,
    Network,

    ErrorPrintNoCartridge,
    ErrorPrintNoPaper,
    ErrorPrintNoRibbon,

    ScanLineNumber, //Линия неизвестна
   
    Exception,
    HardwareError,
    QRRead,

    DefectFront,
    DefectBack,
    DefectBoth
    
}