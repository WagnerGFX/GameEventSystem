using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Encapsulates the EventHub in a ScriptableObject for easy setup of Prefabs and Scenes
    /// </summary>
    [CreateAssetMenu(menuName = "EventHubContainer")]
    public class EventHubContainer : ScriptableObject, IEventHubReference
    {
        IEventHub objEventHub = null;

        public bool HasEventHub()
        {
            return (objEventHub != null);
        }

        public void SetEventHub(IEventHub newEventHub)
        {
            this.objEventHub = newEventHub;
        }

        public IEventHub GetEventHub()
        {
            return objEventHub;
        }
    }
}