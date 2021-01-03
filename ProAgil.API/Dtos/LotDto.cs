using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class LotDto
    {
        public int Id { get; set; }
         [Required(ErrorMessage="Obrigatório")]
        public string Name { get; set; }
         [Required(ErrorMessage="Obrigatório")]
        public double Price { get; set; }
        public string Initial { get; set; }
        public string Final { get; set; }
        public int Quantity { get; set; }
    }
}