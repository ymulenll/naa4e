using System;
using System.Linq;
using WaterpoloScoring.Backend.DAL;
using WaterpoloScoring.Backend.ReadModel;
using WaterpoloScoring.Backend.Services;
using WaterpoloScoring.Framework;
using WaterpoloScoring.Framework.Commands;
using WaterpoloScoring.Framework.Events;
using WaterpoloScoring.ViewModels.Home;

namespace WaterpoloScoring.Services.Home
{
    public class HomeService
    {
        public void DispatchCommand(String matchId, String actionName)
        {
            if (actionName == "start")
            {
                var domainEvent = new MatchStartedEvent(matchId);
                Bus.Send(domainEvent);
            }
            if (actionName == "undo")
            {
                var command = new UndoLastActionCommand(matchId);
                Bus.Send(command);
            }
            if (actionName == "end")
            {
                var command = new MatchEndedEvent(matchId);
                Bus.Send(command);
            }
            if (actionName == "newperiod")
            {
                var command = new PeriodStartedEvent(matchId);
                Bus.Send(command);
            }
            if (actionName == "endperiod")
            {
                var command = new PeriodEndedEvent(matchId);
                Bus.Send(command);
            }
            if (actionName == "goal1")
            {
                var command = new GoalScoredEvent(matchId, TeamId.Home);
                Bus.Send(command);
            }
            if (actionName == "goal2")
            {
                var command = new GoalScoredEvent(matchId, TeamId.Visitors);
                Bus.Send(command);
            }
            if (actionName == "zap")
            {
                // Bypass the bus and persistence of saga instances
                new EventRepository().Empty(matchId);
                SnapshotHelper.Zap(matchId);
            }          
        }

        public MatchViewModel GetCurrentState(String matchId)
        {
            var repo = new EventRepository();
            var events = repo.GetEventStreamForReplay(matchId);
            var matchInfo = EventHelper.PlayEvents(matchId, events.ToList());
            return new MatchViewModel(matchInfo);
        }
    }
}