using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }

        //Métodos Gerais
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            //Se ele for maior que 0 qer dizer que salvou normalmente
            return await _context.SaveChangesAsync() > 0;
        }

        //Eventos
        public Task<Event[]> GetAllEventsAsync(bool? includeSpeaker)
        {
            var query = _context.Events.Include(c => c.Lots);
        }

        public Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }
        Task<Event[]> IProAgilRepository.GetAllEventsByThemeAsync(string theme, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }

        Task<Event[]> IProAgilRepository.GetAllEventsAsync(bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }
        public Task<Event> GetEventByIdAsync(int EventId, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }

        //Palestrantes
        public Task<Event[]> GetSpeakerAsync(int Speaker, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }
        public Task<Event[]> GetAllSpeakerByNameAsync(bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }
        

        Task<Event> IProAgilRepository.GetEventByIdAsync(int EventId, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }

        Task<Event[]> IProAgilRepository.GetAllSpeakerByNameAsync(bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }

        Task<Event[]> IProAgilRepository.GetSpeakerAsync(int Speaker, bool includeSpeaker)
        {
            throw new System.NotImplementedException();
        }
    }
}