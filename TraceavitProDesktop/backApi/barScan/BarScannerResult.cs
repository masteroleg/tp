namespace TraceavitProDesktop.backApi.barScan;

public enum BarScannerResult : int
{
    None = 0,
    Scanned = 1,
    ScanError = 2,
    NoDevice = 3,
    Cancelation = 4
}