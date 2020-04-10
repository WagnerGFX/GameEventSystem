namespace EventSystem
{
    public interface IEventHubRoot
    {
        bool CreateOnAwake { get; }

        void CreateEventHub(EventHubContainer _eventHubMirror = null);

        bool HasEventHub();

        IEventHub GetEventHub();
    }
}