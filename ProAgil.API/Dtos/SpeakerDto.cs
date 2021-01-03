using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class SpeakerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Obrigatório")]
        public string Name { get; set; }
        public string Curriculum { get; set; }
        public string ImgUrl { get; set; }

        [Required(ErrorMessage="Obrigatório")]
        public string Phone { get; set; }
        public string Email { get; set; }
        //Um Palestrante pode ter muitas redes sociais
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<EventDto> Events { get; set; }
    }
}