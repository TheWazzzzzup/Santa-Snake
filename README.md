# Santa Snake

A holiday-themed 3D take on the classic Snake game, built in Unity. You control a reindeer-and-sled train that grows body segments, including Santa, as it collects presents scattered around the map.

The project uses Unity's new Input System for keyboard and joystick/touch steering, and a ScriptableObject-based Game Event system (GameEvent/GameEventListener) to decouple scoring, VFX, SFX, and UI updates from gameplay logic. Dedicated managers handle score tracking, randomized present spawning, high-score tracking, and game-over state. Visual polish comes from Cartoon FX particle effects on present pickups and collisions.
