# Tilemania Platformer 2D

A 2D side-scrolling platformer built with **Unity 6** and the **Universal Render Pipeline (2D)**. Levels are painted with Tilemaps and Rule Tiles. The player runs, jumps, climbs ladders and bounces on special tiles while avoiding patrolling enemies.

This is a learning project, developed step by step to practise the core systems of a Unity 2D game: tilemaps, 2D physics, the Input System, the Animator and Cinemachine cameras.

---

## Features

### Player
- **Running** with physics-based horizontal movement (`Rigidbody2D.linearVelocity`).
- **Jumping**, allowed only when the feet collider touches the `Ground` layer. This prevents mid-air jumps and wall jumps.
- **Ladder climbing**: gravity is disabled while the player overlaps the `Climbing` layer, so they can move up and down freely.
- **Sprite flipping** to always face the direction of movement.
- **Animations** for idle, running and climbing, driven by the `isRunning` and `isClimbing` Animator parameters.
- **No-friction physics material** on the body so the player does not stick to walls.

### Enemies
- **Slime enemy** that patrols platforms automatically, with a looping walk animation.
- **Wall detection**: a forward raycast turns the enemy around when it reaches a wall.
- **Edge detection**: a downward raycast just ahead of the enemy turns it around before it walks off a platform.
- Raycasts are drawn in the Scene view (`Debug.DrawRay`) to make tuning easy.
- Available as a reusable prefab: `Assets/Prefabs/Slime (Enemy).prefab`.

### Level & physics
- Levels built with **Tilemaps**, a **Rule Tile** and a tile palette (`Main Palette`).
- **Composite colliders** on the platform and ladder tilemaps for smooth, efficient collisions.
- **Bouncing tiles** using a bouncy Physics Material 2D (bounciness 1.4) that launches the player into the air.
- Layer-based collision setup (`Ground`, `Climbing`, `Player`, `Background`, `Bouncing`, `Enemies`) configured in the Physics 2D Layer Collision Matrix.

### Camera
- **Cinemachine State-Driven Camera** that switches between virtual cameras based on the player's animation state:
  - **Idle Camera**: used while the player stands still.
  - **Run Camera**: used while running.
  - **Ladder Camera**: used while climbing.
- **Cinemachine Confiner 2D** on every camera, so the view never shows anything outside the level background.

---

## Controls

| Action | Keyboard | Gamepad |
|---|---|---|
| Move left / right | `A` / `D` or `←` / `→` | Left stick |
| Climb up / down (on a ladder) | `W` / `S` or `↑` / `↓` | Left stick |
| Jump | `Space` | South button (A / Cross) |

Input is handled by the **Input System** package through a `PlayerInput` component (`Assets/InputSystem_Actions.inputactions`).

---

## Tech stack

| Area | Technology |
|---|---|
| Engine | Unity **6000.6.3f1** |
| Rendering | Universal Render Pipeline (URP) 2D |
| Input | Input System |
| Camera | Cinemachine |
| Levels | 2D Tilemap + Tilemap Extras (Rule Tiles) |
| 2D art | 2D Sprite, 2D Animation |
| Editor automation | Unity CLI + Pipeline package (`com.unity.pipeline`) |

---

## Project structure

```
Assets/
├── Animations/   # Animator Controllers and clips (Player, SlimeEnemy)
├── Materials/    # Physics Materials 2D (NoFriction, Bouncy Bounce)
├── Prefabs/      # Player, Slime enemy and the tile palette
├── Scenes/       # SampleScene (main level)
├── Scripts/      # Gameplay scripts
│   ├── PlayerMovement.cs
│   └── EnemyMovement.cs
├── Settings/     # URP renderer and pipeline assets
├── Sprites/      # Player, enemies, tiles, background
└── Tiles/        # Tile assets and Rule Tile
```

---

## Getting started

1. Install **Unity 6000.6.3f1** (through Unity Hub or the Unity CLI).
2. Clone the repository:
   ```bash
   git clone https://github.com/sergiobanderas/Tilemania_Plaftorm2D.git
   ```
3. Open the project folder in Unity Hub. On first open, Unity restores the packages listed in `Packages/manifest.json`.
4. Open `Assets/Scenes/SampleScene.unity` and press **Play**.

---

## Credits & license

- Art assets are from the **Super Platformer Assets** pack by **Foxfin**, provided as part of GameDev.tv's *Complete Unity Developer 2D* course.
- These assets are licensed for **personal and learning use only** and **cannot be used in a published game**. To use them commercially, purchase the pack on the [Unity Asset Store](https://assetstore.unity.com/packages/2d/environments/super-platformer-assets-42013).
