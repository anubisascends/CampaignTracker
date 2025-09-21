using CampaignTracker.Models;

namespace CampaignTracker.Repositories.Interfaces
{
    public interface ICampaignRepository
    {
        void CreateCampaign(Campaign campaign);
        Campaign Retrieve(Guid id);
        IDictionary<Guid, string> RetrieveNames();
        void Update(Campaign campaign);
    }
}
