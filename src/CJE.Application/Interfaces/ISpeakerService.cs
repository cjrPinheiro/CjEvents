using CJE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Application.Interfaces
{
    public interface ISpeakerService
    {
        Task<bool> AddSpeaker(Speaker speaker);
        Task<bool> UpdateSpeaker(int id, Speaker speaker);
        Task<bool> DeleteSpeaker(int idSpeaker);

        Task<Speaker[]> GetAllSpeakersByThemeAsync(string theme, bool includeEvents = false);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
        Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents = false);
    }
}
