# Game Event System
- Flexible event system for Unity projects.
- Can be used globally with ScriptableObjects or locally as a Component in GameObjects.
- Useful to handle events that require different levels of access (Global, Factions, Groups, Individuals)
- Easy to avoid a null reference hell between many GameObjects.
- Light enough to send a large volume of messages each second without drop in frames.

## Differences from the original
The original code required public delegates. This project uses a separate class to encapsulate private EventHandlers.

Now EventArgs is used as the base class to identify the events. All you need is to create classes inherited from it.

The EventHandler and EventArgs are default classes in .NET that help handling delegates easier.

## Example Project
Projet created to test the performance of the event system by spawning objects that send messages to other objects each frame.

Depending on the hardware and platform can reach to millions of messages each second.

## Credits
Original concept by Mike Mittleman in [Unite 2008 - Techniques for making reusable code](https://www.youtube.com/watch?v=FNyzfrujJtk)

Original code by Will R. Miller in [A Type-Safe Event System for Unity3D](http://www.willrmiller.com/?p=87) and [Gist - Unity3D Event System](https://gist.github.com/wmiller/3903205)
