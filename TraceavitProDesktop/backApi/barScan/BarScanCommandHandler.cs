using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.backApi.barScan;

public class BarScanCommandHandler : IRequestHandler<BarScanCommand, (string, BarScannerResult)>
{
    private readonly DataBag _bag;

    public BarScanCommandHandler(DataBag bag)
    {
        _bag = bag;
    }

    public async Task<(string, BarScannerResult)> Handle(BarScanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Log.Information("BarScannerService[{method}] started", nameof(BarScanCommandHandler));
            
            while (_bag.DevData.BarScannerResultDev == BarScannerResult.None)
            {
                await Task.Delay(300, cancellationToken);
            }

            var result = _bag.DevData.BarScannerResultDev == BarScannerResult.Scanned
                ? (_bag.DevData.BarScannerDataDev, BarScannerResult.Scanned)
                : (string.Empty, BarScannerResult.ScanError);


            Log.Information("BarScannerService[{method}] result:{result}", nameof(BarScanCommandHandler), result);
            _bag.DevData.BarScannerResultDev = BarScannerResult.None;
            return result;
        }
        catch (Exception e)
        {
            Log.Fatal(e, "ScanBarCode");
        }

        return (string.Empty, BarScannerResult.ScanError);
    }
}