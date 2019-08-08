using UnityEngine;

//Encapsulates GameEventManager in a ScriptableObject to create global managers.
[CreateAssetMenu(menuName = "GameEventContainer")]
public class GameEventContainer : ScriptableObject
{
    GameEventManager _gevManager = new GameEventManager();

    public GameEventManager EventManager {
        get
        {
            return _gevManager;
        } 
    }
}
