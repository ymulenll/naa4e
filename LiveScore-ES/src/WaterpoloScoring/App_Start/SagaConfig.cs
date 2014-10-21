using WaterpoloScoring.Framework;
using WaterpoloScoring.Framework.Events;
using WaterpoloScoring.Framework.Sagas;

namespace WaterpoloScoring
{
    public class SagaConfig
    {
        public static void Initialize()
        {
            Bus.RegisterSaga<MatchStartedEvent, MatchSaga>();
        }
    }
}