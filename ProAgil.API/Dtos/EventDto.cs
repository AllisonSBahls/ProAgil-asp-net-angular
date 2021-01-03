using System.Collections.Generic;

namespace ProAgil.API.Dtos
{
    public class EventDto
    {
         public int Id { get; set; }
        public string Local { get; set; }
        public string DateEvent { get; set; }
        public string Theme { get; set; }
        public int TotalParticipants { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<LotDto> Lots { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<SpeakerDto> Speakers { get; set; }

    }
}