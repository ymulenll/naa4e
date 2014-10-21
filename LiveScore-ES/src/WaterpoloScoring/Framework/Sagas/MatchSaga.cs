using WaterpoloScoring.Backend.DAL;
using WaterpoloScoring.Backend.Services;
using WaterpoloScoring.Framework.Commands;
using WaterpoloScoring.Framework.Events;

namespace WaterpoloScoring.Framework.Sagas
{
    public class MatchSaga : SagaBase<MatchData>, 
        IStartWithMessage<MatchStartedEvent>,
        ICanHandleMessage<MatchEndedEvent>,
        ICanHandleMessage<PeriodStartedEvent>,
        ICanHandleMessage<PeriodEndedEvent>,
        ICanHandleMessage<GoalScoredEvent>,
        ICanHandleMessage<MatchInfoChangedEvent>,
        ICanHandleMessage<UndoLastActionCommand>
    {
        private readonly EventRepository _repo = new EventRepository();

        public void Handle(MatchStartedEvent message)
        {
            // This code only serves the purpose of the RavenDB example here. 
            _repo.BeginHistory(message.MatchId);

            // Persist the event
            _repo.Save(message);

            // Set the ID of the saga
            SagaId = message.MatchId;

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        public void Handle(UndoLastActionCommand message)
        {
            _repo.UndoLastAction(message.MatchId);

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        //public void Handle(ZapArchiveCommand message)
        //{
        //    _repo.Empty(message.MatchId);
        //    SnapshotHelper.Zap(message.MatchId);

        //    // Signal that match information has changed 
        //    NotifyMatchInfoChanged(message.MatchId);
        //}

        public void Handle(MatchEndedEvent message)
        {
            // Just persist the event
            _repo.Save(message);

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        public void Handle(PeriodStartedEvent message)
        {
            // Just persist the event
            _repo.Save(message);

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        public void Handle(PeriodEndedEvent message)
        {
            // Just persist the event
            _repo.Save(message);

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        public void Handle(GoalScoredEvent message)
        {
            // Just persist the event
            _repo.Save(message);

            // Signal that match information has changed 
            NotifyMatchInfoChanged(message.MatchId);
        }

        public void Handle(MatchInfoChangedEvent message)
        {
            SnapshotHelper.Update(message.MatchId);
        }

        private static void NotifyMatchInfoChanged(string matchId)
        {
            var theEvent = new MatchInfoChangedEvent(matchId);
            Bus.Send(theEvent);
        }
    }
}