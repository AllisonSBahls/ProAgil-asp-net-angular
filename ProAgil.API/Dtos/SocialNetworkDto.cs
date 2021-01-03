using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class SocialNetworkDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Obrigatório")]
        public string Name { get; set; }
        public string Url { get; set; }
    }
}