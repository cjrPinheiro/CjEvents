using AutoMapper;
using CJE.Aplication.Dtos;
using CJE.Domain.Entities;
using CJE.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.API.Business.Helpers
{
    public class CjEventsProfile : Profile
    {
        public CjEventsProfile()
        {
            CreateMap<Event, EventDto>()
                .ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkDto>()
                .ReverseMap();
            CreateMap<Speaker, SpeakerDto>()
                .ReverseMap();
            CreateMap<Batch, BatchDto>()
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ReverseMap();
            CreateMap<User, UserExistingDto>()
                .ReverseMap();
            
        }
    }
}
