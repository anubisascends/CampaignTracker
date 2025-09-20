using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CampaignTracker.Modesl;

public sealed partial class Campaign : ObservableObject
{
    [ObservableProperty]
    public partial Guid Id { get; set; }
    [ObservableProperty]
    public partial string Name { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Note> Notes { get; set; } = [];
}
