using System;

namespace ReserGO.Utils.Event
{
    public interface IEvent
    {
        void Publish<TValue, TMessageType>(TMessageType message) where TMessageType : IMessage<TValue>;
        void Publish<TValue, TMessageType, TSubscriber>(TMessageType message) where TMessageType : IMessage<TValue>;
        void Publish<TValue, TMessageType>(TMessageType message, Type subscription) where TMessageType : IMessage<TValue>;
        Subscription<TMessageType> Subscribe<TMessageType>(Type subscriber, Action<TMessageType> action);
        void Unscribe<TMessageType>(Subscription<TMessageType> subscription);

    }
}