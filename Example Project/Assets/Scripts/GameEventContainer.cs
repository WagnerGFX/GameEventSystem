using System;
using UnityEngine;

//Encapsulates GameEventManager in a ScriptableObject to create global managers.
[CreateAssetMenu(menuName = "GameEventContainer")]
public class GameEventContainer : ScriptableObject, IGameEventManager
{
    private GameEventManager _gevManager = new GameEventManager();

    public void RegisterListener<T>(EventHandler<T> listener) where T : EventArgs
    {
        _gevManager.RegisterListener<T>(listener);
    }


    public void UnregisterListener<T>(EventHandler<T> listener) where T : EventArgs
    {
        _gevManager.UnregisterListener<T>(listener);
    }


    public void RaiseEvent<T>(object sender, T eventInfo) where T : EventArgs
    {
        _gevManager.RaiseEvent(sender, eventInfo);
    }


    public void ClearListeners<T>() where T : EventArgs
    {
        _gevManager.ClearListeners<T>();
    }


    public void ClearAllListeners()
    {
        _gevManager.ClearAllListeners();
    }
}
