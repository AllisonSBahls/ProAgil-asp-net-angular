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
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lots)
            .Include(c => c.SocialNetworks);
            
            if (includeSpeaker)
            {
                query = query
                .Include(se => se.SpeakerEvents)
                .ThenInclude(s => s.Speaker);
            }
            
            query = query.OrderByDescending(c => c.DateEvent);
            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(c => c.Lots)
            .Include(c => c.SocialNetworks);

            if (includeSpeaker)
            {
                query = query
                .Include(se => se.SpeakerEvents)
                .ThenInclude(s => s.Speaker);
            }
            query = query
            .OrderByDescending(c => c.DateEvent)
            .Where(c => c.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }
        

        public async Task<Event> GetEventByIdAsync(int EventId, bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if (includeSpeaker)
            {
                query = query
                .Include(se => se.SpeakerEvents)
                .ThenInclude(s => s.Speaker);
            }
            query = query.OrderByDescending(c => c.DateEvent)
                .Where(c => c.Id == EventId);

            return await query.FirstOrDefaultAsync();       
        }

        //Palestrantes
        public async Task<Speaker> GetSpeakerAsync(int SpeakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(c => c.SocialNetworks);

            if (includeEvents)
            {
                query = query
                .Include(se => se.SpeakerEvents)
                .ThenInclude(e => e.Event);
            }
            query = query.OrderBy(s => s.Name)
            .Where(s => s.Id == SpeakerId);

            return await query.FirstOrDefaultAsync();       
        }

        public async Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(c => c.SocialNetworks);

            if (includeEvents)
            {
                query = query
                .Include(se => se.SpeakerEvents)
                .ThenInclude(e => e.Event);
            }
            query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();       
           }
    }
}