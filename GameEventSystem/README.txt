INSTRUCTIONS
---------------
- Add one EventHudRoot component in the scene with createOnAwake = true.
- Add EventHudComponent in the GameObjects that will need it.
- Create one ScriptableObject and set to the root and the "mirror" components to link all of them automatically.
- Use GetEventHub() to have access to the event system.
- Create different events by implementing IEventArgs with all the needed data inside.
- Implement with structs to ease Garbage Collection, only use classes when necessary.


!!! ALWAYS !!! unregister from events when the object is destroyed to avoid errors.


USEFUL TIPS
---------------
- Only use CreateEventHub() to create a new empty root from code.
- Use ? to check for null references. This will make any Script self-contained.
- You can also register/unregister the listeners when the object is enabled/disabled for better control.
- You can setup multiple event roots. Useful to send/receive events to the whole Scene or to selected groups.
- Save references using the IEventHud interface to easly change the EventHud with a custom one using debug functions.