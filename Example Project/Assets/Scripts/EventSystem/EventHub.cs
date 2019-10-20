using System;
using System.Collections.Generic;

namespace EventSystem
{
    public class EventHub : IEventHub
    {
        Dictionary<Type, object> eventHolderList = new Dictionary<Type, object>();

        /// <summary>
        /// Register a function to listen for events based on the parameter class.
        /// Usage: RegisterListener&lt;InheritedEventArgs&gt;(OnEventTriggered);
        /// </summary>
        /// <param name="listener">Function to recieve events.</param>
        /// <typeparam name="T">Parameter must inherit from EventArgs.</typeparam>
        public void RegisterListener<T>(EventHandler<T> listener) where T : EventArgs
        {
            Type eventType = typeof(T);

            InstantiateListener<T>(eventType);

            EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
            oEvent.RegisterListener(listener);
        }

        public void UnregisterListener<T>(EventHandler<T> listener) where T : EventArgs
        {
            Type eventType = typeof(T);

            if (CheckListeners(eventType))
            {
                EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
                oEvent.UnregisterListener(listener);
            }
        }

        public void RaiseEvent<T>(object sender, T eventInfo) where T : EventArgs
        {
            Type eventType = typeof(T);

            if (CheckListeners(eventType))
            {
                EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
                oEvent.RaiseEvent(sender, eventInfo);
            }
        }

        public void ClearListeners<T>() where T : EventArgs
        {
            Type eventType = typeof(T);

            if (CheckListeners(eventType))
            {
                EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
                oEvent.ClearListeners();
            }
        }

        public void ClearAllListeners()
        {
            eventHolderList.Clear();
        }

        private bool CheckListeners(Type eventType)
        {
            return eventHolderList.ContainsKey(eventType);
        }

        private void InstantiateListener<T>(Type eventType) where T : EventArgs
        {
            // Instantiate EventHolder for given type on first use
            if (!eventHolderList.ContainsKey(eventType) || eventHolderList[eventType] == null)
            {
                eventHolderList[eventType] = new EventHolder<T>();
            }
        }
    }
}