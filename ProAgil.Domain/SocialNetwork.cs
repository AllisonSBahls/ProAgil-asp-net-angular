using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? EventId{ get; set; }
        public Event Events { get; }
        public int? SpeakerId{ get; set; }
        public Speaker Spearker { get; }

    }
}