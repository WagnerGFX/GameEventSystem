using UnityEngine;

//Encapsulates GameEventManager in MonoBehaviour to create local managers.
public class GameEventComponent : MonoBehaviour
{
    GameEventManager _gevManager = new GameEventManager();

    public GameEventManager EventManager {
        get
        {
            return _gevManager;
        } 
    }
}