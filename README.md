# Project2Game

---
   ###### author(s): [Justin stewart](https://github.com/stewartjustinl), [Brett Sumser](https://github.com/bsumser), [Jake Petersen](https://github.com/jpeter17)

---
- [Description](#description)
- [Usage](#usage)
- [Level Generation](#levelgeneration)
- [Enemy Pathing](#enemypathing)
- [License](#license)
---
## Description

A top-down Rogue-like shooter that has been built using the Unity Engine, utilizing 
[NavMeshComponents](https://github.com/Unity-Technologies/NavMeshComponents) for runtime NavMesh baking. 

Hosted using the Unity WebGL Package. 

---
## Usage 

The game can be played [here](https://veph.itch.io/project-2) using the password 'dev'

---
## Level Generation 

The ["LevelScene"](https://github.com/stewartjustinl/Project2Game/blob/main/Game/Assets/Scenes/LevelScene.unity) 
is a scene in Unity that contains a room responsible for the level generation. The level is spawned from [prefab 
rooms](https://github.com/stewartjustinl/Project2Game/tree/main/Game/Assets/Prefabs) that have different openings 
in different directions (Left, Right, Top, and Bottom). Each room also contains a gameObject at each room opening 
with a script that will spawn another room in that location. At each room spawn, the [RoomSpawner](https://github.
com/stewartjustinl/Project2Game/blob/main/Game/Assets/Scripts/RoomSpawner.cs) script picks a random room from the 
array of rooms that have the correct opening direction, and instantiates it in the location of the spawner 
gameObject.

---
##  Enemy Pathing
Enemies are able to determine walkable surfaces by using [Unity NavMesh](https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html). Each of the prefab rooms used to build the level has a mesh placed on the floor, and
the enemies have a NavMeshAgent component to them. The [EnemyController](https://github.com/stewartjustinl/Project2Game/blob/main/Game/Assets/Scripts/EnemyController.cs) script maintains a reference to the player location,
which allows them to track the players position on the level and move towards them.

Normally though, NavMeshes in Unity are unable to be baked onto gameObjects at runtime. Thankfully, Unity provides
an optional component called
[NavMeshComponents](https://github.com/Unity-Technologies/NavMeshComponents), 
that allows for runtime NavMesh baking. To do so, all you need is to attatch a NavMesh component to the object,
and have a [script](https://github.com/stewartjustinl/Project2Game/blob/main/Game/Assets/Scripts/NavMeshBaker.cs) 
attatched as well that will call BuildNavMesh() on the object.

---
## License

See the [COPYING](COPYING) file for license rights and limitations (GNU GPLv3).
