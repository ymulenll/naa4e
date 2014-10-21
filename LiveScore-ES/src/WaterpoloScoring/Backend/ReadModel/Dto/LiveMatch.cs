using System;

namespace WaterpoloScoring.Backend.ReadModel.Dto
{
    public class LiveMatch  
    {
        public LiveMatch()
        {
            Id = "";
            State = MatchState.ToBePlayed;
            CurrentScore = new Score();
            IsBallInPlay = false;
            CurrentPeriod = 0;
            ScorePeriod1 = "0-0";
            ScorePeriod2 = "0-0";
            ScorePeriod3 = "0-0";
            ScorePeriod4 = "0-0";
        }

        public String Id { get; set; }
        public String Team1 { get; set; }
        public String Team2 { get; set; }
        public Score CurrentScore { get; set; }
        public Boolean IsBallInPlay { get; set; }
        public Int32 CurrentPeriod { get; set; }
        public Int32 TimeInPeriod { get; set; }
        public MatchState State { get; set; }
        public string ScorePeriod1 { get; set; }
        public string ScorePeriod2 { get; set; }
        public string ScorePeriod3 { get; set; }
        public string ScorePeriod4 { get; set; }
    }
}