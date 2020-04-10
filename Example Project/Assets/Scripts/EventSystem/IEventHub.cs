using System;

namespace EventSystem
{
    public interface IEventHub
    {
        void RegisterListener<T>(Action<T> listener) where T : IEventArgs;


        void UnregisterListener<T>(Action<T> listener) where T : IEventArgs;


        void RaiseEvent<T>(T eventInfo) where T : IEventArgs;


        void ClearListeners<T>() where T : IEventArgs;


        void ClearAllListeners();
    }
}