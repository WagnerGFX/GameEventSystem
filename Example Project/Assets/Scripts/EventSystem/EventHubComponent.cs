using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Encapsulates the EventHub in a Component for easy access between scripts in the same GameObject
    /// </summary>
    public class EventHubComponent : MonoBehaviour, IEventHubReference
    {
        IEventHub objEventHub = null;
        [SerializeField] EventHubContainer eventHubMirror = null;

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
            //If any script make a request during Start()
            Start();
            
            return objEventHub;
        }

        void Start()
        {
            //Auto-load if the reference exists
            if (objEventHub == null && eventHubMirror != null)
            {
                objEventHub = eventHubMirror.GetEventHub();
            }
        }
    }
}