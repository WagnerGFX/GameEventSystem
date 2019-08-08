using System;
using System.Collections.Generic;

public class GameEventManager
{
    Dictionary<Type, object> eventListeners = new Dictionary<Type, object>();

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

        GameEvent<T> oEvent = (GameEvent<T>)eventListeners[eventType];
        oEvent.RegisterListener(listener);
    }

    public void UnregisterListener<T>(EventHandler<T> listener) where T : EventArgs
    {
        Type eventType = typeof(T);

        if (CheckListeners(eventType))
        {
            GameEvent<T> oEvent = (GameEvent<T>)eventListeners[eventType];
            oEvent.UnregisterListener(listener);
        }
    }

    public void RaiseEvent<T>(object sender, T eventInfo) where T : EventArgs
    {
        Type eventType = typeof(T);

        if (CheckListeners(eventType))
        {
            GameEvent<T> oEvent = eventListeners[eventType] as GameEvent<T>;
            oEvent.RaiseEvent(sender, eventInfo);
        }
    }
    
    public void ClearListeners<T>() where T : EventArgs
    {
        Type eventType = typeof(T);

        if (CheckListeners(eventType))
        {
            GameEvent<T> oEvent = eventListeners[eventType] as GameEvent<T>;
            oEvent.ClearListeners();
        }
    }

    public void ClearAllListeners()
    {
        eventListeners.Clear();
    }

    private bool CheckListeners(Type eventType)
    {
        //Check if GameEvent of given type exists
        return eventListeners.ContainsKey(eventType);
    }

    private void InstantiateListener<T>(Type eventType) where T : EventArgs
    {
        // Instantiate GameEvent for given type on first use
        if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null)
        {
            eventListeners[eventType] = new GameEvent<T>();
        }
    }
}