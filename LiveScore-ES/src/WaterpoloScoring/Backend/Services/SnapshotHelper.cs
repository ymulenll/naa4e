using System;
using System.Linq;
using WaterpoloScoring.Backend.DAL;
using WaterpoloScoring.Backend.ReadModel.Dto;

namespace WaterpoloScoring.Backend.Services
{
    public class SnapshotHelper
    {
        public static void Update(String matchId)
        {
            var repo = new EventRepository();
            var events = repo.GetEventStreamForReplay(matchId);
            var matchInfo = EventHelper.PlayEvents(matchId, events.ToList());

            using (var db = new WaterpoloContext())
            {
                var lm = (from m in db.Matches where m.Id == matchId select m).FirstOrDefault();
                if (lm == null)
                {
                    var liveMatch = new LiveMatch
                    {
                        Id = matchId,
                        Team1 = matchInfo.Team1,
                        Team2 = matchInfo.Team2,
                        State = matchInfo.State,
                        IsBallInPlay = matchInfo.IsBallInPlay,
                        CurrentScore = matchInfo.CurrentScore,
                        CurrentPeriod = matchInfo.CurrentPeriod,
                        TimeInPeriod = 0
                    };
                    db.Matches.Add(liveMatch);
                }
                else
                {
                    lm.State = matchInfo.State;
                    lm.IsBallInPlay = matchInfo.IsBallInPlay;
                    lm.CurrentScore = matchInfo.CurrentScore;
                    lm.CurrentPeriod = matchInfo.CurrentPeriod;
                    lm.TimeInPeriod = 0;
                    lm.ScorePeriod1 = matchInfo.GetPartial(1).ToString();
                    lm.ScorePeriod2 = matchInfo.GetPartial(2).ToString();
                    lm.ScorePeriod3 = matchInfo.GetPartial(3).ToString();
                    lm.ScorePeriod4 = matchInfo.GetPartial(4).ToString();
                }
                db.SaveChanges();
            }
        }

        public static void Zap(String matchId)
        {
            using (var db = new WaterpoloContext())
            {
                var lm = (from m in db.Matches where m.Id == matchId select m).FirstOrDefault();
                if (lm != null)
                {
                    db.Matches.Remove(lm);
                }
                db.SaveChanges();
            }
        } 
    }
}