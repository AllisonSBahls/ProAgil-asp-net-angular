namespace ProAgil.API.Dtos
{
    public class LotDto
    {
        public int Id { get; set; } 
       public string Name{ get; set; }
       public double Price { get; set; }
       public string Initial { get; set; }
       public string Final { get; set; }
       public int Quantity { get; set; }
    }
}