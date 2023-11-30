

namespace EventCreateDataAccess.Models
{
    public class EventCreateModel
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;

        public EventCreateModel()
        {
            
        }
    }
}
