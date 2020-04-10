# Game Event System
- Flexible event system for Unity projects.
- Decouple the communication between many GameObjects and avoid a null reference hell.
- Easy to use with Components and ScriptableObjects for Scenes and Prefabs setup.
- Useful to handle events that require different levels of access (Global, Factions, Groups, Individuals)
- Light enough to send a large volume of messages each frame using little CPU and without overworking the Garbage Collector.

## Differences from the original
The original code required public delegates. This project uses a separate class to encapsulate private events.

The IEventArgs interface is used to identify the events. All you need to do is implement structs using it and use as the argument in the function to call.

Structs can go through the memory Stack, avoiding extra work for the Garbage Collector. Use classes only when necessary.

## Example Project
Project created to test the performance of the event system by spawning objects that send messages to other objects each frame.

Depending on the hardware and platform, it can generate millions of messages each second.

## Credits
Original concept by Mike Mittleman in [Unite 2008 - Techniques for making reusable code](https://www.youtube.com/watch?v=FNyzfrujJtk)

Original code by Will R. Miller in [A Type-Safe Event System for Unity3D](http://www.willrmiller.com/?p=87) and [Gist - Unity3D Event System](https://gist.github.com/wmiller/3903205)