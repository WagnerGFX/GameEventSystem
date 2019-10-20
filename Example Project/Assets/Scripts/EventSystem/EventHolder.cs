using System;
using System.Linq;

/// <summary>
/// Encapsulates the event handler to allow dynamic instancing for inherited EventArgs types.
/// </summary>
/// <typeparam name="T">Type must inherit from EventArgs</typeparam>

namespace EventSystem
{
    public class EventHolder<T> where T : EventArgs
    {
        event EventHandler<T> evHandler;

        public void RegisterListener(EventHandler<T> listener)
        {
            if (evHandler == null || !evHandler.GetInvocationList().Contains(listener))
            {
                evHandler += listener;
            }
        }

        public void UnregisterListener(EventHandler<T> listener)
        {
            evHandler -= listener;
        }

        public void RaiseEvent(object sender, T info)
        {
            evHandler?.Invoke(sender, info);
        }

        public void ClearListeners()
        {
            evHandler = null;
        }
    }
}