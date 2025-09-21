using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CampaignTracker.Models;

public sealed partial class Note : ObservableObject
{
    [ObservableProperty]
    public partial Guid Id { get; set; } = Guid.NewGuid();
    [ObservableProperty]
    public partial string Title { get; set; } = Resources.Strings.Note.NewNote;
    [ObservableProperty]
    public partial string Data { get; set; }
    [ObservableProperty]
    public partial ObservableCollection<Note> Children { get; set; }

}
