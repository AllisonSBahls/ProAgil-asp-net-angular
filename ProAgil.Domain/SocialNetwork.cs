using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Url { get; set; }
        public int? EventId{ get; set; }
        public Event Events { get; set; }
        public int? SpeakerId{ get; set; }
        public Speaker Spearker { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }

    }
}