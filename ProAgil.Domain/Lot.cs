using System;

namespace ProAgil.Domain
{
    public class Lot
    {
       public int Id { get; set; } 
       public string Name{ get; set; }
       public double Price { get; set; }
       public DateTime? Initial { get; set; }
       public DateTime? Final { get; set; }
       public int Quantity { get; set; }
       public int EventId { get; set; }
       public Event Event { get;}
    }
}