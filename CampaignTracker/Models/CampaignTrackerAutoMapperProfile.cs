using AutoMapper;
using CampaignTracker.Dtos;

namespace CampaignTracker.Models
{
    internal sealed class CampaignTrackerAutoMapperProfile : Profile
    {
        public CampaignTrackerAutoMapperProfile()
        {
            CreateMap<Note, NoteDto>();
            CreateMap<Campaign, CampaignDto>();

            CreateMap<NoteDto, Note>();
            CreateMap<CampaignDto, Campaign>();
        }
    }
}
