using System;
using System.Linq;

/// <summary>
/// Encapsulates the event system to allow dynamic instancing for inherited EventArgs types.
/// </summary>
/// <typeparam name="T">Type must inherit from EventArgs</typeparam>
public class GameEvent<T> where T : EventArgs
{
    event EventHandler<T> GameEventHandler;

    public void RegisterListener(EventHandler<T> listener)
    {
        if (GameEventHandler == null || !GameEventHandler.GetInvocationList().Contains(listener)) {
            GameEventHandler += listener;
        }
    }

    public void UnregisterListener(EventHandler<T> listener)
    {
        GameEventHandler -= listener;
    }

    public void RaiseEvent(object sender, T info)
    {
        GameEventHandler?.Invoke(sender, info);
    }

    
    public void ClearListeners()
    {
        GameEventHandler = null;
    }
}
