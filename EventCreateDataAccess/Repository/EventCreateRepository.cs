using EventCreateDataAccess.Context;
using EventCreateDataAccess.Models;


namespace EventCreateDataAccess.Repository
{
    public class EventCreateRepository
    {
        private readonly EventCreateDbContext _context;

        public EventCreateRepository()
        {
            _context = new EventCreateDbContext();
        }

        public async Task<EventCreateModel> CreateAsync(EventCreateModel model)
        {
            await _context.Entities.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<EventCreateModel> DeleteAsync(int Id)
        {
            var model = _context.Entities.Find(Id);

            _context.Entities.Remove(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<EventCreateModel> UpdateAsync(EventCreateModel model)
        {
            var existingEvent = _context.Entities.Find(model.Id);

            if (existingEvent != null)
            {
                existingEvent.EventName = model.EventName;
                existingEvent.EventDescription = model.EventDescription;

                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<EventCreateModel> GetByIdAsync(int Id)
        {
            var events = _context.Entities.Find(Id);

            return events;
        }

        public async Task<List<EventCreateModel>> GetAllAsync()
        {
            List<EventCreateModel> result = _context.Entities.ToList();

            return result;
        }
    }
}
