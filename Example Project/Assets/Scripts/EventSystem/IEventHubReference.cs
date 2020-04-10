namespace EventSystem
{
    public interface IEventHubReference
    {
        bool HasEventHub();

        void SetEventHub(IEventHub newEventHub);

        IEventHub GetEventHub();
    }
}
