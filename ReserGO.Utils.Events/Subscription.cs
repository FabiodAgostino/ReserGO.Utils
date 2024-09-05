using System;

namespace ReserGO.Utils.Event
{
    public class Subscription<TMessage> : IDisposable
    {
        private readonly Event EventAggregator;
        private bool isDisposed;

        public Action<TMessage> Action { get; private set; }
        public Type Subscriber { get; private set; }

        public Subscription(Type subscriber, Action<TMessage> action, Event eventAggregator)
        {
            Subscriber = subscriber;
            Action = action;
            EventAggregator = eventAggregator;
        }

        ~Subscription()
        {
            if (!isDisposed)
                Dispose();
        }

        public void Dispose()
        {
            EventAggregator.Unscribe(this);
            isDisposed = true;
        }
    }
}