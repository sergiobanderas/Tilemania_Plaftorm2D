# Tilemania Platformer 2D

2D tilemap platformer built as a course project (student-facing: explanations matter as much as the code).

## Communication & code style

- Always communicate with the user in Spanish.
- Explain Unity concepts step by step in Spanish.
- Write C# code using English names for classes, methods and variables.
- Write code comments in English.
- Follow Unity and C# best practices.

## Tech stack

- Unity **6000.6.3f1** with **URP 2D** (`com.unity.render-pipelines.universal`).
- **Input System** (`com.unity.inputsystem`) via a `PlayerInput` component with *Send Messages* (`OnMove`, `OnJump`, ...). Do not use the legacy `Input` class.
- **Cinemachine** (`com.unity.cinemachine`) with a State-Driven Camera tied to the player's Animator states.
- **Tilemap + Tilemap Extras** for level building.
- Physics: `Rigidbody2D` using `linearVelocity` (Unity 6 API, not the obsolete `velocity`). A Physics Material 2D without friction prevents sticking to walls.

## Project structure

- `Assets/Scenes/SampleScene.unity` — the main (and only) game scene.
- `Assets/Scripts/` — gameplay scripts (one `MonoBehaviour` per file, file name = class name).
  - `PlayerMovement.cs` — run, jump (only when feet touch `Ground`), sprite flip, ladder climbing (gravity off while feet touch `Climbing`).
  - `EnemyMovement.cs` — patrolling enemy that reverses direction on `OnTriggerExit2D` (edge detection).
- `Assets/Animations/` — Animator Controllers and clips (player run/climb/idle, `SlimeEnemy`).
- `Assets/Sprites/`, `Assets/Tiles/`, `Assets/Prefabs/`, `Assets/Materials/`, `Assets/Settings/` (URP assets).

## Layers

`Ground`, `Climbing`, `Player`, `Background`, `Bouncing`, `Enemies`. Gameplay checks rely on these names via `LayerMask.GetMask(...)`, so do not rename them without updating the scripts. Collision rules live in `ProjectSettings/Physics2DSettings.asset`.

## Animator parameters (player)

- `isRunning` (bool), `isClimbing` (bool). Keep names in sync between scripts and the Animator Controller.

## Working with the Unity Editor (Unity CLI)

- The project has the **Pipeline package** (`com.unity.pipeline`) installed, so the Editor can be driven with the Unity CLI.
- Check the connection first: `unity status --project-path "d:\UnityProjects_26_27\Tilemania_Plaftorm2D"` (state must be `ready`).
- Modify scenes, GameObjects, prefabs and assets through the live Editor (`unity command ...`, `unity command script eval ...`), **never by hand-editing `.unity`, `.prefab` or `.asset` YAML**.
- After editing scripts, use `unity recompile` and read the console to confirm there are no compile errors.
- If the Editor does not respond, check for Safe Mode (compile errors) with `unity status` before anything else.

## Git

- Commit messages describe the feature added (e.g. "Climb on Ladder", "State-Driven Cameras").
- Do not commit `Library/`, `Temp/`, `Logs/`, `obj/` or `UserSettings/` changes unless explicitly asked.
