using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CampaignTracker.Models;

public sealed partial class Campaign : ObservableObject
{
    [ObservableProperty]
    public partial Guid Id { get; set; } = Guid.NewGuid();
    [ObservableProperty]
    public partial string Name { get; set; } = Resources.Strings.Campaign.NewCampaign;
    [ObservableProperty]
    public partial NoteCollection Notes { get; set; } = [];
}
