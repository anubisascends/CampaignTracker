using CampaignTracker.Models;
using CampaignTracker.Repositories;
using CampaignTracker.Repositories.Interfaces;
using CampaignTracker.ViewModels;
using CampaignTracker.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Navigation;

namespace CampaignTracker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost Host { get; } = new HostBuilder()
        .AddServices()
        .AddViewModels()
        .AddViews()
        .Build();

    protected override void OnStartup(StartupEventArgs e) => Host.Start();
}

internal static class AppExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddAutoMapper(config => 
            {
                config.AddProfile<CampaignTrackerAutoMapperProfile>();
            });

            services.AddTransient<ICampaignRepository, CampaignFileRepository>();
        });

        return builder;
    }

    public static IHostBuilder AddViews(this IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddHostedService<RootView>();
        });

        return builder;
    }

    public static IHostBuilder AddViewModels(this IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddSingleton<RootViewModel>();
        });
        return builder;
    }
}