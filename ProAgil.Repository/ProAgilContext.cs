using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Lot> Lots { get; set; }


        //Especificando a relação de N para N da classe criada S
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<SpeakerEvent>().HasKey(PE => new {PE.EventId, PE.SpeakerId});
        }
    }
}