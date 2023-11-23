using System;
using System.Collections.Generic;
using Logictime.Protobuf;
using TraceavitProDesktop.backApi.barScan;
using TraceavitProDesktop.infrastructure;
using TraceavitProDesktop.models.view;
using TraceavitProDesktop.services;

namespace TraceavitProDesktop.models;

[SingletonService]
public class DataBag
{
    public AuthUser User { get; set; }
    
    public SetLineResult LineState { get; set; }
    public bool IsServiceShift { get; set; }

    public JobData Job { get; set; }
    public List<JobData> JobsList { get; set; }

    public Operations PreviousView { get; set; }


    public PauseReasonSelected PauseReason { get; set; }

    public Exception Exception { get; set; }

    public DevData DevData { get; set; }
    public SettingsData Settings { get; set; }

    public DataBag()
    {
        DevData = new DevData();
        Settings = new SettingsData()
        {
            TimeOutViewDialog = TimeSpan.FromMilliseconds(500)
        };
    }
}

public class SettingsData
{
    /// <summary>
    /// Сканироанный номер линии
    /// </summary>
    public int LineBarCode { get; set; }

    public string Server { get; set; }

    public TimeSpan TimeOutViewDialog { get; set; }
    public int StationId { get; set; }
    public StationType StationType { get; set; }
}

public class DevData
{
    public BarScannerResult BarScannerResultDev { get; set; }
    public string BarScannerDataDev { get; set; }
}