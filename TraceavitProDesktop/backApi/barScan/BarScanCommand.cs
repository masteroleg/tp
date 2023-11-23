using MediatR;

namespace TraceavitProDesktop.backApi.barScan;

public class BarScanCommand :  IRequest<(string, BarScannerResult)>
{
    
}