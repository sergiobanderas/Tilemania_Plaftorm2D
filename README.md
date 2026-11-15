# Tilemania Platformer 2D

A 2D side-scrolling platformer built with **Unity 6** and the **Universal Render Pipeline (2D)**. Levels are painted with Tilemaps and Rule Tiles. The player runs, jumps, climbs ladders and bounces on special tiles, shoots patrolling enemies and has to avoid spikes: touching an enemy or a hazard is deadly.

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
- **Shooting**: the `Attack` action spawns a bullet (`Instantiate`) at a `Gun` spawn point in front of the player.

### Death
- The player **dies** when its body collider touches the `Enemies` or `Hazards` layers.
- An `isAlive` flag stops movement, jumping, climbing and shooting once the player is dead.
- **Dying animation**: a `Dying` Animator trigger and an *Any State → Dying* transition, so death plays from any state.
- **Death kick**: the player is launched into the air (`deathKick`, configurable in the Inspector). Gravity is restored first, so dying on a ladder does not make the player float away.

### Bullets
- Reusable prefab: `Assets/Prefabs/Bullet.prefab` (shooting star sprite).
- Flies in a straight line in the direction the player is facing (Dynamic `Rigidbody2D` with no gravity and continuous collision detection).
- **Destroys enemies** tagged `Enemy` on contact (works with both trigger and solid enemy colliders).
- Hitting a wall leaves the bullet stuck for 1 second before it is removed.
- Has its own `Bullets` layer, which only collides with `Ground` and `Enemies`.

### Enemies
- **Slime enemy** that patrols platforms automatically, with a looping walk animation.
- **Wall detection**: a forward raycast turns the enemy around when it reaches a wall.
- **Edge detection**: a downward raycast just ahead of the enemy turns it around before it walks off a platform.
- Raycasts are drawn in the Scene view (`Debug.DrawRay`) to make tuning easy.
- Tagged `Enemy`, so bullets can destroy it.
- Available as a reusable prefab: `Assets/Prefabs/Slime (Enemy).prefab`.

### Level & physics
- Levels built with **Tilemaps**, a **Rule Tile** and a tile palette (`Main Palette`).
- **Composite colliders** on the platform and ladder tilemaps for smooth, efficient collisions.
- **Bouncing tiles** using a bouncy Physics Material 2D (bounciness 1.4) that launches the player into the air.
- **Hazards**: spike tiles painted on their own `Hazards` tilemap (trigger collider that follows the sprite's physics shape). Touching them kills the player.
- Layer-based collision setup (`Ground`, `Climbing`, `Player`, `Background`, `Bouncing`, `Enemies`, `Hazards`, `Bullets`) configured in the Physics 2D Layer Collision Matrix.
- 2D lighting with a **Global Light 2D** that lights every sorting layer, including `Hazards`.

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
| Shoot | Left mouse button or `Enter` | West button (X / Square) |

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
├── Animations/   # Animator Controllers and clips (Player incl. Dying, SlimeEnemy)
├── Materials/    # Physics Materials 2D (NoFriction, Bouncy Bounce)
├── Prefabs/      # Player, Slime enemy and Bullet
├── Scenes/       # SampleScene (main level)
├── Scripts/      # Gameplay scripts
│   ├── PlayerMovement.cs   # Movement, climbing, death and shooting
│   ├── EnemyMovement.cs    # Enemy patrol with wall/edge raycasts
│   └── Bullet.cs           # Bullet movement and enemy destruction
├── Settings/     # URP renderer and pipeline assets
├── Sprites/      # Player, enemies, tiles, spikes, bullet, background
└── Tiles/        # Tile assets (incl. Spikes), Rule Tile and Main Palette
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
