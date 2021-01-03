using System.Collections.Generic;

namespace ProAgil.API.Dtos
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Curriculum { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //Um Palestrante pode ter muitas redes sociais
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<EventDto> Events { get; set; }
    }
}