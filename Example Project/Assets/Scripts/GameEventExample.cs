using UnityEngine;

public class GameEventExample : MonoBehaviour
{
    [SerializeField] GameEventContainer globalEvSys = null;

    private static OnSomethingHappened oArg = new OnSomethingHappened();

    void Start() //Or OnEnable()
	{
		globalEvSys?.RegisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
    
    void OnDestroy() //Or OnDisable()
    {
		globalEvSys?.UnregisterListener<OnSomethingHappened>(OnSomethingHappened);
    }
	
	void OnValidate()
    {
        if (globalEvSys == null) {
            Debug.LogWarning(name + ": Global Event Manager not set. Raised events will be ignored.", this);
        }
    }
    
	public void MakeSomethingHappen()
    {
		EventController.eventCount += 1;
		globalEvSys?.RaiseEvent(this, oArg);
    }
	
    public void OnSomethingHappened(object sender, OnSomethingHappened eSpin)
	{
		EventController.messageCount += 1;
    }
	
	
	//Use ? to check for null references. This will make the GameObject/Prefab self-contained.
	// ! ! ! ALWAYS ! ! ! unregister from events when the object is destroyed to avoid errors.
	
	//Useful Tips
	//You can register/unregister the listeners when the object is enabled/disabled.
	//You can have multiple event managers. Useful to send/receive event globally and locally.
	//OnValidate can give warnings when the manager is not set in the inspector.
	//Use a static empty argument if there is no data transfer to minimize memory usage.
}
