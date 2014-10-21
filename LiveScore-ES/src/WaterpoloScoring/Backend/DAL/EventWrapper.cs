using WaterpoloScoring.Framework;

namespace WaterpoloScoring.Backend.DAL
{
    public class EventWrapper
    {
        public EventWrapper(DomainEvent theEvent)
        {
            TheEvent = theEvent;
        }
        public DomainEvent TheEvent { get; private set; } 
    }
}