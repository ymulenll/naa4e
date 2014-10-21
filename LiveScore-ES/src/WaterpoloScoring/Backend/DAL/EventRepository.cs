using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using WaterpoloScoring.Backend.ReadModel;
using WaterpoloScoring.Framework;

namespace WaterpoloScoring.Backend.DAL
{
    public class EventRepository
    {
        private IDocumentSession DocumentSession { get; set; }

        public EventRepository()
        {
            DocumentSession = RavenDbConfig.Instance.OpenSession();
        }

        public EventRepository Save(DomainEvent domainEvent)
        {
            var eventWrapper = new EventWrapper(domainEvent);
            DocumentSession.Store(eventWrapper);
            var key = DocumentSession.Advanced.GetDocumentId(eventWrapper);
            GetHistory(domainEvent.SagaId).Records.Add(key);

            DocumentSession.SaveChanges();
            return this;
        }

        public MatchHistory BeginHistory(String matchId)
        {
            var history = new MatchHistory(matchId);
            DocumentSession.Store(history);
            DocumentSession.SaveChanges();
            return history;
        }

        public MatchHistory GetHistory(String matchId)
        {
            //// Checks for existence without loading the document
            //var metadata = DocumentSession.Advanced.DocumentStore.DatabaseCommands.Head(matchId);
            //if (metadata == null)
            //    return null;

            return DocumentSession.Load<MatchHistory>(matchId);
        }

        public void UndoLastAction(String id)
        {
            //var lastEvent = DocumentSession.Query<StateChangeEvent>()
            //    .OrderByDescending(e => e.Timestamp)
            //    .FirstOrDefault(m => m.MatchId == id);

            var lastEvent = (from e in GetEventStream(id) select e).LastOrDefault();
            if (lastEvent != null)
            {
                var key = DocumentSession.Advanced.GetDocumentId(lastEvent); 
                DocumentSession.Delete(lastEvent);
                GetHistory(id).Records.Remove(key);
            }

            DocumentSession.SaveChanges();
        }

        public IList<EventWrapper> GetEventStream(String id)
        {
            var history = GetHistory(id);
            if (history == null)
                return new List<EventWrapper>();

            var keys = history.Records;
            var list = DocumentSession.Load<EventWrapper>(keys);
            return list;  

            //return DocumentSession
            //    .Query<StateChangeEvent>()
            //    .Where(t => t.MatchId == id)
            //    .OrderBy(t => t.Timestamp);
        }

        public IList<DomainEvent> GetEventStreamForReplay(String id)
        {
            var history = GetHistory(id);
            if (history == null)
                return new List<DomainEvent>();

            var keys = history.Records;
            var list = DocumentSession.Load<EventWrapper>(keys);
            return (from e in list select e.TheEvent).ToList();

            //return DocumentSession
            //    .Query<StateChangeEvent>()
            //    .Where(t => t.MatchId == id)
            //    .OrderBy(t => t.Timestamp);
        }

        public void Empty(String id)
        {
            var records = GetEventStream(id);
            foreach (var r in records)
            {
                if (r != null)
                    DocumentSession.Delete(r);
            }
            var history = GetHistory(id);
            if (history != null)
                DocumentSession.Delete(history);
            DocumentSession.SaveChanges();
        }
    }
}