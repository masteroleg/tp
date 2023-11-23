using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using Logictime.Protobuf;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.ClientFactory;
using Serilog;
using TraceavitProDesktop.models;
using TraceavitProDesktop.views;

namespace TraceavitProDesktop.infrastructure;

public class Builder
{
    private IServiceCollection services;

    public Builder(Application application)
    {
        services = new ServiceCollection();

        IConfiguration Configuration;
        var cfgBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
        Configuration = cfgBuilder.Build();

        services.AddSingleton<IConfiguration>(Configuration);
        services.AddSingleton(Configuration);
        services.AddSingleton(MapperConfig.GetMappingConfig());
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddServices();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Builder>());

        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        services.AddCodeFirstGrpcClient<IApiService>(o =>
        {
            // Address of grpc server
            o.Address = new Uri(Configuration.GetValue<string>("Server")!);

            // another channel options (based on best practices docs on https://docs.microsoft.com/en-us/aspnet/core/grpc/performance?view=aspnetcore-6.0)
            o.ChannelOptionsActions.Add(options =>
            {
                options.HttpHandler = new SocketsHttpHandler()
                {
                    // keeps connection alive
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),

                    // allows channel to add additional HTTP/2 connections
                    EnableMultipleHttp2Connections = true
                };
            });
        });


        var provider = services.BuildServiceProvider();

        var bag = provider.GetRequiredService<DataBag>();

        bag.Settings.StationId = Configuration.GetValue<int>("StationId");
        bag.Settings.StationType = Configuration.GetValue<StationType>("StationType");
        bag.Settings.Server = Configuration.GetValue<string>("Server");


        var mainWindow = provider.GetRequiredService<MainWindow>();
        application.MainWindow = mainWindow;

        /*---------------------*/
        Log.Logger = new LoggerConfiguration().WriteTo.RichTextBox(mainWindow.LogRichTextBox).CreateLogger();
        /*---------------------*/

        Log.Information("Start App");


        mainWindow.Show();
    }
}