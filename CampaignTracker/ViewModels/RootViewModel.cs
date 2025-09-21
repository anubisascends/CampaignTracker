using CampaignTracker.Models;
using CampaignTracker.Repositories.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampaignTracker.ViewModels;

public sealed partial class RootViewModel(ICampaignRepository repository) : WindowViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand), nameof(SaveAsCommand), nameof(NotesCommand), 
        nameof(ImagesCommand), nameof(PlayersCommand), nameof(NonPlayersCommand))]
    public partial Campaign? ActiveCampaign { get; set; }
    [ObservableProperty]
    public partial object? FrameContent { get; set; }
    public ICampaignRepository Repository { get; } = repository;

    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnSave() 
    {
        Repository.Update(ActiveCampaign);
    }

    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnSaveAs() { }

    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnOpen() { }

    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnImages()
    {
        
    }
    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnPlayers()
    {

    }
    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnNonPlayers()
    {

    }
    [RelayCommand(CanExecute = nameof(ActiveCampaignIsValid))]
    public void OnNotes()
    {
        if (FrameContent is not NoteCollection)
            FrameContent = ActiveCampaign.Notes;
    }

    public bool ActiveCampaignIsValid() => ActiveCampaign is not null;

    public override void OnNew()
    {
        ActiveCampaign = new();
        Repository.CreateCampaign(ActiveCampaign);
    }
}
