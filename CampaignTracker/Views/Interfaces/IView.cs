using CampaignTracker.ViewModels.Interfacaces;

namespace CampaignTracker.Views.Interfaces
{
    public interface IView<T> where T : IViewModel
    {
        T ViewModel { get; }
    }
}
