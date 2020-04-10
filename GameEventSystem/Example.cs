using UnityEngine;
using EventSystem;

public class Example : MonoBehaviour
{
    private IEventHub objEventHub;

    void Start()
    {
        //Grabs EventHub reference
        objEventHub = GetComponent<IEventHubReference>()?.GetEventHub();
        
        objEventHub?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
    }

    void OnDestroy()
    {
        objEventHub?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
    }

    public void MakeSomethingHappen()
    {
        objEventHub?.RaiseEvent(new OnSomethingHappened(this));
    }

    public void OnSomethingHappened(OnSomethingHappened eArg)
    {
        //Do Something.
    }
}
