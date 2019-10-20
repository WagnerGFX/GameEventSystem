using System;
using UnityEngine;

namespace EventSystem
{
    //Encapsulates EventHub in a Component to create local managers.
    public class EventHubComponent : MonoBehaviour, IEventHub
    {
        private EventHub _evHub = new EventHub();

        public void RegisterListener<T>(EventHandler<T> listener) where T : EventArgs
        {
            _evHub.RegisterListener<T>(listener);
        }


        public void UnregisterListener<T>(EventHandler<T> listener) where T : EventArgs
        {
            _evHub.UnregisterListener<T>(listener);
        }


        public void RaiseEvent<T>(object sender, T eventInfo) where T : EventArgs
        {
            _evHub.RaiseEvent(sender, eventInfo);
        }


        public void ClearListeners<T>() where T : EventArgs
        {
            _evHub.ClearListeners<T>();
        }


        public void ClearAllListeners()
        {
            _evHub.ClearAllListeners();
        }
    }
}