namespace ProAgil.Domain
{
    public class SpeakerEvent
    {
        //Relação de N para N criando uma nova classe
        public int SpeakerId{ get; set; }
        public Speaker Speaker { get; }
        public int EventId { get; set; }
        public Event Event { get; }
    }
}