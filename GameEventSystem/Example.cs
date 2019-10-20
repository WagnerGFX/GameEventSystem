using UnityEngine;
using EventSystem;

public class Example : MonoBehaviour
{
    [SerializeField] EventHubContainer globalEvSys = null;
	[SerializeField] EventHubComponent localEvSys = null;
    
    void Start()
	{
        globalEvSys?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
		localEvSys?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
    
    void OnDestroy()
	{
        globalEvSys?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
		localEvSys?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
	
    void OnValidate()
    {
        if (globalEvSys == null) {
            Debug.LogWarning(name + ": Global Event System not set. Raised events will be ignored.", this);
        }
		
		if (localEvSys == null) {
            Debug.LogWarning(name + ": Local Event System not set. Raised events will be ignored.", this);
        }
    }
	
	public void MakeSomethingHappen(int someValue)
    {
		globalEvSys?.RaiseEvent(this, new OnSomethingHappened(someValue));
	}
	
    public void OnSomethingHappened(object sender, OnSomethingHappened eArg)
	{
		//Do Something.
    }
	
	
	//Use ? to check for null references. This will make the GameObject/Prefab self-contained.
	// ! ! ! ALWAYS ! ! ! unregister from events when the object is destroyed to avoid errors.
	
	//Useful Tips
	//You can register/unregister the listeners when the object is enabled/disabled.
	//You can have multiple event managers. Useful to send/receive event globally and locally.
	//OnValidate can give warnings when the manager is not set in the inspector.
	//Use a static empty argument if there is no data transfer to minimize memory usage.
}
