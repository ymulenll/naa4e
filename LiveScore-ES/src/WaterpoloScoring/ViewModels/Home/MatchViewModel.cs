using WaterpoloScoring.Backend.ReadModel;

namespace WaterpoloScoring.ViewModels.Home
{
    public class MatchViewModel
    {
        public MatchViewModel(Match m)
        {
            CurrentMatch = m;
        }
        public Match CurrentMatch { get; private set; }
    }
}