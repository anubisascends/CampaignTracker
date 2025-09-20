using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CampaignTracker.Modesl;

public sealed partial class Note : ObservableObject
{
    [ObservableProperty]
    public partial Guid Id { get; set; }
    [ObservableProperty]
    public partial string Title { get; set; }
    [ObservableProperty]
    public partial string Data { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Note> Children { get; set; }

}
