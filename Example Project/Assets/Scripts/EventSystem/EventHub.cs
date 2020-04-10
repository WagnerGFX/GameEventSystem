using System;
using System.Collections.Generic;

namespace EventSystem
{
    /// <summary>
    /// Manages all listeners from different types
    /// </summary>
    public class EventHub : IEventHub
    {
        Dictionary<Type, object> eventHolderList = new Dictionary<Type, object>();

        /// <summary>
        /// Register a function to listen for events based on the parameter's Type.
        /// Usage: RegisterListener&lt;MyEventArgs&gt;(OnEventTriggered);
        /// </summary>
        /// <param name="listener">Function to recieve events.</param>
        /// <typeparam name="T">Parameter must inherit from IEventArgs.</typeparam>
        public void RegisterListener<T>(Action<T> listener) where T : IEventArgs
        {
            Type eventType = typeof(T);

            InstantiateListener<T>(eventType);

            EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
            oEvent.RegisterListener(listener);
        }

        public void UnregisterListener<T>(Action<T> listener) where T : IEventArgs
        {
            Type eventType = typeof(T);

            if (CheckListeners(eventType))
            {
                EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
                oEvent.UnregisterListener(listener);
            }
        }

        public void RaiseEvent<T>(T eventArgs) where T : IEventArgs
        {
            Type eventType = typeof(T);

            if (CheckListeners(eventType))
            {
                EventHolder<T> oEvent = eventHolderList[eventType] as EventHolder<T>;
                oEvent.RaiseEvent(eventArgs);
            }
        }

        public void ClearListeners<T>() where T : IEventArgs
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
            foreach (KeyValuePair<Type, object> entry in eventHolderList)
            {
                IEventHolderClear oHolder = entry.Value as IEventHolderClear;
                oHolder.ClearListeners();
            }
            eventHolderList.Clear();
        }

        private bool CheckListeners(Type eventType)
        {
            return eventHolderList.ContainsKey(eventType);
        }

        private void InstantiateListener<T>(Type eventType) where T : IEventArgs
        {
            // Instantiate EventHolder for given type on first use
            if (!eventHolderList.ContainsKey(eventType) || eventHolderList[eventType] == null)
            {
                eventHolderList[eventType] = new EventHolder<T>();
            }
        }
    }
}