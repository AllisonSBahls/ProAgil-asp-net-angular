using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //Todas as entidades devem herdas essas funções
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;         
         Task<bool> SaveChangeAsync();

         //Eventos
         Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker);
         Task<Event[]> GetAllEventsAsync(bool includeSpeaker);
         Task<Event> GetEventByIdAsync(int EventId, bool includeSpeaker);
         
        //Speaker
        Task<Event[]> GetAllSpeakerByNameAsync(bool includeSpeaker);
        Task<Event[]> GetSpeakerAsync(int Speaker, bool includeSpeaker);
    }
}