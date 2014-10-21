using System;

namespace WaterpoloScoring.Framework.Events
{
    public class MatchStartedEvent : DomainEvent
    {
        public MatchStartedEvent(String matchId)
        {
            MatchId = matchId;
            
            // Command class has SagaId property used to find saga the message relates to. 
            // (Simpler schema than more general ConfigureHowToFindSaga method in NServiceBus)
            SagaId = matchId;
        }

        public String MatchId { get; private set; }
    }
}