namespace ReserGO.Utils.Event
{
    public interface IMessage<TValue>
    {
        TValue Value { get; }
    }
}