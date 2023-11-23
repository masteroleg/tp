using System;
using System.Timers;
using System.Windows.Controls;
using DevExpress.Mvvm.CodeGenerators;

namespace TraceavitProDesktop.views.operation.jobs.process;

public partial class JobProcessHeader : UserControl
{
    public JobProcessHeader()
    {
        InitializeComponent();
    }
}

[GenerateViewModel]
public partial class Ticker
{
    [GenerateProperty] private DateTime _currentTime;

    public Ticker()
    {
        Timer timer = new Timer();
        timer.Interval = 1000; // 1 second updates
        timer.Elapsed += (sender, args) =>
        {
            CurrentTime = DateTime.Now;
        };
        timer.Start();
    }
}