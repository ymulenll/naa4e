using System;
using System.Linq;
using WaterpoloScoring.Backend.DAL;
using WaterpoloScoring.Backend.ReadModel.Dto;

namespace WaterpoloScoring.Services.Live
{
    public class LiveService
    {
        public LiveMatch GetLiveMatch(String matchId)
        {
            using (var db = new WaterpoloContext())
            {
                var lm = (from m in db.Matches where m.Id == matchId select m).FirstOrDefault();
                if (lm == null)
                    return new LiveMatch() {Id = matchId};
                return lm;
            }
        }

    }
}