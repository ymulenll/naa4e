namespace WaterpoloScoring.Framework
{
    public interface ICanHandleMessage<in T> where T : Message
    {
        void Handle(T message);
    }
}