using System;
using System.Collections.Generic;
using WaterpoloScoring.Backend.ReadModel;
using WaterpoloScoring.Framework;
using WaterpoloScoring.Framework.Events;

namespace WaterpoloScoring.Backend.Services
{
    public class EventHelper
    {
        public static Match PlayEvents(String id, IList<DomainEvent> events)
        {
            var match = new Match(id);

            foreach (var e in events)
            {
                if (e == null)
                    return match;

                if (e is MatchStartedEvent)
                    match.Start();

                if (e is MatchEndedEvent)
                    match.Finish();

                if (e is PeriodStartedEvent)
                    match.StartPeriod();

                if (e is PeriodEndedEvent)
                    match.EndPeriod();

                var @event = e as GoalScoredEvent;
                if (@event != null)
                {
                    var actual = @event;
                    match.Goal(actual.TeamId);
                }
            }

            return match;
        }
    }
}