using CJE.Aplication.Interfaces;
using CJE.Domain.Entities;
using CJE.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Aplication.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerPersist _speakerRepository;

        public SpeakerService(ISpeakerPersist speakerPersist)
        {
            _speakerRepository = speakerPersist;
        }
        public async Task<bool> AddSpeaker(Speaker @speaker)
        {
            try
            {
                await _speakerRepository.AddAsync(@speaker);
                return await _speakerRepository.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
        public async Task<bool> UpdateSpeaker(int id, Speaker @speaker)
        {
            try
            {
                var speakerExist = await _speakerRepository.GetSpeakerByIdAsync(id, false);
                if (speakerExist == null) return false;

                _speakerRepository.Update(@speaker);
                return await _speakerRepository.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
        public async Task<bool> DeleteSpeaker(int idSpeaker)
        {
            try
            {
                Speaker delSpeaker = await _speakerRepository.GetSpeakerByIdAsync(idSpeaker, false);

                if (delSpeaker == null) throw new Exception($"Event: {idSpeaker} not found in database.");
                _speakerRepository.Delete(delSpeaker);
                return await _speakerRepository.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            try
            {
                return await _speakerRepository.GetAllSpeakersAsync(includeEvents);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Speaker[]> GetAllSpeakersByThemeAsync(string name, bool includeEvents = false)
        {
            try
            {
                return await _speakerRepository.GetAllSpeakersByNameAsync(name, includeEvents);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int Id, bool includeEvents = false)
        {
            try
            {
                return await _speakerRepository.GetSpeakerByIdAsync(Id, includeEvents);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
