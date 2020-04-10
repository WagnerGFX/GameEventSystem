using System;
using System.Linq;

namespace EventSystem
{
    /// <summary>
    /// Encapsulates the event handler to allow dynamic instancing for implemented IEventArgs types.
    /// </summary>
    /// <typeparam name="T">Type must inherit from IEventArgs</typeparam>
    public class EventHolder<T> : IEventHolderClear where T : IEventArgs
    {
        event Action<T> evHandler;

        public void RegisterListener(Action<T> listener)
        {
            if (evHandler == null || !evHandler.GetInvocationList().Contains(listener))
            {
                evHandler += listener;
            }
        }

        public void UnregisterListener(Action<T> listener)
        {
            evHandler -= listener;
        }

        public void RaiseEvent(T eventArgs)
        {
            evHandler?.Invoke(eventArgs);
        }

        public void ClearListeners()
        {
            evHandler = null;
        }
    }
}