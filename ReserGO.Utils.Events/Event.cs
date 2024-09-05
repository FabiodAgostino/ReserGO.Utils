using System.Collections;

namespace ReserGO.Utils.Event
{
    public class Event : IEvent
    {
        private Dictionary<Type, IList> subscribers;

        public Event()
        {
            subscribers = new Dictionary<Type, IList>();
        }

        public void Publish<TValue, TMessageType>(TMessageType message) where TMessageType : IMessage<TValue>
        {
            Type t = typeof(TMessageType);
            IList actions;
            if (subscribers.ContainsKey(t))
            {
                actions = new List<Subscription<TMessageType>>(subscribers[t].Cast<Subscription<TMessageType>>());
                foreach (Subscription<TMessageType> action in actions)
                {
                    action.Action.DynamicInvoke(message);
                }
            }
        }

        public void Publish<TValue, TMessageType, TSubscriber>(TMessageType message) where TMessageType : IMessage<TValue>
        {
            Type t = typeof(TMessageType);
            IList actions;
            if (subscribers.ContainsKey(t))
            {
                actions = new List<Subscription<TMessageType>>(subscribers[t].Cast<Subscription<TMessageType>>());
                foreach (Subscription<TMessageType> action in actions)
                {
                    if (action.Subscriber.Equals(typeof(TSubscriber)))
                    {
                        action.Action.DynamicInvoke(message);
                    }

                }
            }
        }

        public void Publish<TValue, TMessageType>(TMessageType message, Type subscription) where TMessageType : IMessage<TValue>
        {
            Type t = typeof(TMessageType);
            IList actions;
            if (subscribers.ContainsKey(t))
            {
                actions = new List<Subscription<TMessageType>>(subscribers[t].Cast<Subscription<TMessageType>>());
                foreach (Subscription<TMessageType> action in actions)
                {
                    if (action.Subscriber.Equals(subscription))
                    {
                        action.Action.DynamicInvoke(message);
                    }
                }
            }
        }

        public Subscription<TMessageType> Subscribe<TMessageType>(Type subscriber, Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actions;
            var actiondetail = new Subscription<TMessageType>(subscriber, action, this);

            if (!subscribers.TryGetValue(t, out actions))
            {
                actions = new List<Subscription<TMessageType>>();
                actions.Add(actiondetail);
                subscribers.Add(t, actions);
            }
            else
            {
                actions.Add(actiondetail);
            }

            return actiondetail;
        }

        public void Unscribe<TMessageType>(Subscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (subscribers.ContainsKey(t))
            {
                subscribers[t].Remove(subscription);
            }
        }

        public void Unscribe<TMessageType, TSubscriber>()
        {
            Type t = typeof(TMessageType);
            if (subscribers.ContainsKey(t))
            {

                IList<Subscription<TMessageType>> allMessageSubscriptions = new List<Subscription<TMessageType>>(subscribers[t].Cast<Subscription<TMessageType>>());
                allMessageSubscriptions.Where(s => typeof(TSubscriber) == s.Subscriber)
                    .ToList()
                    .ForEach(subscription => allMessageSubscriptions.Remove(subscription));
            }
        }
    }
}
