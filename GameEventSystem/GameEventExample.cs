using UnityEngine;

public class GameEventExample : MonoBehaviour
{
    [SerializeField] GameEventContainer globalEvSys = null;
	[SerializeField] GameEventComponent localEvSys = null;
    
    void Start()
	{
        globalEvSys?.EventManager?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
		localEvSys?.EventManager?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
    
    void OnDestroy()
	{
        globalEvSys?.EventManager?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
		localEvSys?.EventManager?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
	
    void OnValidate() {
        if (globalEvSys == null) {
            Debug.LogWarning(name + ": Global Event Manager not set. Raised events will be ignored.", this);
        }
		
		if (localEvSys == null) {
            Debug.LogWarning(name + ": Local Event Manager not set. Raised events will be ignored.", this);
        }
    }
	
	public void MakeSomethingHappen(int someValue) {
		globalEvSys?.EventManager?.RaiseEvent(this, new OnSomethingHappened(someValue));
	}
	
    public void OnSomethingHappened(object sender, OnSomethingHappened eSpin)
	{
		//Do Something.
    }
	
	
	//Use ? to check for null references. This will make the GameObject/Prefab self-contained.
	// ! ! ! ALWAYS ! ! ! unregister from events when the object is destroyed to avoid errors.
	
	//Useful Tips
	//You can register/unregister the listeners when the object is enabled/disabled.
	//You can have multiple event managers. Useful to send/receive event globally and locally.
	//OnValidate can give warnings when the manager is not set in the inspector.
}
