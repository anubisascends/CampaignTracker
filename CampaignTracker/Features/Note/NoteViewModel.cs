using CampaignTracker.Models;
using CampaignTracker.ViewModels.Interfacaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CampaignTracker.Features.Note
{
    public sealed partial class NoteViewModel : ObservableObject, IViewModel
    {
        public NoteCollection? Notes { get; set; }
    }
}
