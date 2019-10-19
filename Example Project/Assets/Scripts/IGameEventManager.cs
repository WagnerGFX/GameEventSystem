using System;

public interface IGameEventManager
{
    void RegisterListener<T>(EventHandler<T> listener) where T : EventArgs;


    void UnregisterListener<T>(EventHandler<T> listener) where T : EventArgs;


    void RaiseEvent<T>(object sender, T eventInfo) where T : EventArgs;


    void ClearListeners<T>() where T : EventArgs;


    void ClearAllListeners();
}
