using CampaignTracker.ViewModels;
using CampaignTracker.Views.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Windows.Navigation;

namespace CampaignTracker.Views;

/// <summary>
/// Interaction logic for RootView.xaml
/// </summary>
public partial class RootView : IView<RootViewModel>, IHostedService
{
    public RootView(RootViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public RootViewModel ViewModel { get; }
    public NavigationService NavigationService { get; }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Show();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Close();
        return Task.CompletedTask;
    }
}