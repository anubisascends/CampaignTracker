using CampaignTracker.ViewModels.Interfacaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampaignTracker.ViewModels
{
    public abstract class ViewModel : ObservableObject, IViewModel
    {
    }

    public abstract partial class WindowViewModel : ViewModel
    {
        [RelayCommand]
        public void OnExit()
        {
            App.Host.StopAsync();
        }

        [RelayCommand]
        public virtual void OnNew()
        {
            
        }
    }
}
