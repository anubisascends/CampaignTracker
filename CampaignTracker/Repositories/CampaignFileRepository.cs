using AutoMapper;
using CampaignTracker.Dtos;
using CampaignTracker.Models;
using CampaignTracker.Repositories.Interfaces;
using System.IO;
using System.Text.Json;

namespace CampaignTracker.Repositories
{
    public sealed class CampaignFileRepository(IMapper mapper) : ICampaignRepository
    {
        public IMapper Mapper { get; } = mapper;

        public void CreateCampaign(Campaign campaign)
        {
            var dir = Path.Combine(GetDirectory(), campaign.Id.ToString());

            _ = Directory.CreateDirectory(dir);

            File.WriteAllText(Path.Combine(dir, "name"), campaign.Name);

            var notesDto = Mapper.Map<IEnumerable<NoteDto>>(campaign.Notes);
            File.WriteAllText(Path.Combine(dir, "notes.json"), JsonSerializer.Serialize(notesDto));

            var campaignDto = Mapper.Map<CampaignDto>(campaign);    
            File.WriteAllText(Path.Combine(dir, "campaign.cmpg"), JsonSerializer.Serialize(campaignDto));
        }

        public Campaign Retrieve(Guid id)
        {
            var dir = Path.Combine(GetDirectory(), id.ToString());
            var noteContents = File.ReadAllText(Path.Combine(dir, "notes.json"));
            var campaignContents = File.ReadAllText(Path.Combine(dir, "campaign.cmpg"));

            var notesDto = JsonSerializer.Deserialize<IEnumerable<NoteDto>>(noteContents);
            var notes = Mapper.Map<IEnumerable<Note>>(notesDto);

            var campaignDto = JsonSerializer.Deserialize<CampaignDto>(campaignContents);
            var result = Mapper.Map<Campaign>(campaignDto);

            result.Notes = new(notes);

            return result;
        }

        public IDictionary<Guid, string> RetrieveNames()
        {
            var dirs = Directory.GetDirectories(GetDirectory());
            var result = new Dictionary<Guid, string>();

            foreach(var dir in dirs)
            {
                var id = Guid.Parse(Path.GetDirectoryName(dir));
                var name = File.ReadAllText(Path.Combine(dir, "name"));

                result.Add(id, name);
            }

            return result;
        }

        public void Update(Campaign campaign) => CreateCampaign(campaign);

        private string GetDirectory()
        {
            var result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Anubisware",
                "Campaign Tracker");

            _ = Directory.CreateDirectory(result);

            return result;
        }
    }
}
