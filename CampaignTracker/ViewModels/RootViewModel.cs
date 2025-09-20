using CampaignTracker.Modesl;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CampaignTracker.ViewModels;

public sealed partial class RootViewModel : ViewModel
{
    [ObservableProperty]
    public partial Campaign? ActiveCampaign { get; set; }
}
