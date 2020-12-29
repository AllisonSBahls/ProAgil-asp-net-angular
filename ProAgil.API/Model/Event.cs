namespace ProAgil.API.Model
{
    public class Event
    {
        public int EventId { get; set; }
        public string Local { get; set; }
        public string DateEvent { get; set; }
        public string Theme { get; set; }
        public int QtyPeoples { get; set; }
        public string Lot { get; set; }
        public string ImageUri { get; set; }
    }
}