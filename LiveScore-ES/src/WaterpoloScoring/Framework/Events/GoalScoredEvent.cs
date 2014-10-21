using System;
using WaterpoloScoring.Backend.ReadModel;

namespace WaterpoloScoring.Framework.Events
{
    public class GoalScoredEvent : DomainEvent
    {
        public GoalScoredEvent(String matchId, TeamId teamId)
        {
            MatchId = matchId;
            TeamId = teamId;
            
            // Command class has SagaId property used to find saga the message relates to. 
            // (Simpler schema than more general ConfigureHowToFindSaga method in NServiceBus)
            SagaId = matchId;
        }

        public String MatchId { get; private set; }
        public TeamId TeamId { get; private set; }
    }
}