using UnityEngine;

namespace EventSystem
{
    /// <summary>
    /// Encapsulates the root EventHub Reference, can't be set more than once. When destroyed will kill all listeners.
    /// </summary>
    public class EventHubRoot : MonoBehaviour, IEventHubRoot
    {
        EventHub objEventHub = null;
        [SerializeField] EventHubContainer eventHubMirror = null;
        [SerializeField] bool createOnAwake = false;

        /// <summary>
        /// Will create a new EventHub during Awake(). Set in the Inspector.
        /// </summary>
        public bool CreateOnAwake { get { return createOnAwake; } }

        /// <summary>
        /// Create a new EventHub only if none is set. Use in code.
        /// </summary>
        public void CreateEventHub(EventHubContainer _eventHubMirror = null)
        {
            if (objEventHub == null)
            {
                objEventHub = new EventHub();

                if (_eventHubMirror != null)
                {
                    eventHubMirror = _eventHubMirror;
                }

                eventHubMirror?.SetEventHub(objEventHub);
            }
        }

        public bool HasEventHub()
        {
            return (objEventHub != null);
        }

        public IEventHub GetEventHub()
        {
            return this.objEventHub;
        }
        void Awake()
        {
            if (createOnAwake)
            {
                CreateEventHub();
            }
        }

        void OnDestroy()
        {
            //To avoid reference persistance across Scenes
            eventHubMirror?.SetEventHub(null);

            //Kills all listeners
            objEventHub?.ClearAllListeners();
        }
    }
}