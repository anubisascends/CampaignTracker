using System.Collections.ObjectModel;

namespace CampaignTracker.Models
{
    public sealed class NoteCollection : ObservableCollection<Note>
    {
        public NoteCollection() : base()
        {
            
        }

        public NoteCollection(IEnumerable<Note> collection) : base(collection)
        {
            
        }
    }
}
