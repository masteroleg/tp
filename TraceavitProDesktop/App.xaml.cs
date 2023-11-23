using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Serilog;
using Serilog.Events;
using TraceavitProDesktop.infrastructure;

namespace TraceavitProDesktop;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var builder = new Builder(this);

        Dispatcher.UnhandledException += Dispatcher_UnhandledException;

        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += AppDomain_UnhandledException;

        var currentApp = Application.Current;
        currentApp.DispatcherUnhandledException += Application_DispatcherUnhandledException;

        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    }

    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Log.Logger.Write(LogEventLevel.Fatal, e.Exception.InnerException, "TaskScheduler | Sender:{snd}", sender);
    }

    private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Log.Logger.Write(LogEventLevel.Fatal, e.Exception, "Application | Sender:{snd}", sender);
    }

    private void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Log.Logger.Write(LogEventLevel.Fatal, "AppDomain | Sender:{snd} || ExcObject: {obj}", sender,e.ExceptionObject);
    }

    private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Log.Logger.Write(LogEventLevel.Fatal, e.Exception, "Dispatcher | Sender:{snd}", sender);
    }
}