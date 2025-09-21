using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignTracker.Dtos;

public record struct NoteDto(Guid Id, string Title, string Data, IEnumerable<NoteDto> Children);
