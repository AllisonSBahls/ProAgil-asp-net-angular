using System.Linq;
using AutoMapper;
using ProAgil.API.Dtos;
using ProAgil.Domain;

namespace ProAgil.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //N for N
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Speakers, opt=>{
                    opt.MapFrom(src => src.SpeakerEvents.Select(x => x.Speaker).ToList());
                }).ReverseMap();
            CreateMap<Lot, LotDto>().ReverseMap().ReverseMap();
            
            CreateMap<Speaker, SpeakerDto>()
                .ForMember(dest => dest.Events, opt=>{
                    opt.MapFrom(src => src.SpeakerEvents.Select(x => x.Event).ToList());
                }).ReverseMap();


            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
        }
    }
}