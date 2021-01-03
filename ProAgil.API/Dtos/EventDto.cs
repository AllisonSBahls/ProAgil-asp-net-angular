using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
         
        [Required(ErrorMessage="Obrigatório")]
        public string Local { get; set; }

        [Required(ErrorMessage="Obrigatório")]
        public string DateEvent { get; set; }
        
        [Required(ErrorMessage="Obrigatório")]
        public string Theme { get; set; }

        [Range(1, 120000, ErrorMessage ="Participanter devem ser entre 1 e 120000")]
        public int TotalParticipants { get; set; }
       
        [Required(ErrorMessage="Obrigatório")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage="Obrigatório")]
        public string Phone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage="Obrigatório")]
        public string Email { get; set; }
        public List<LotDto> Lots { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<SpeakerDto> Speakers { get; set; }

    }
}