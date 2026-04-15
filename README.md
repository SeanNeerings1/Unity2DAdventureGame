# Game Design Document (GDD)

## 1. Game Overview

**Title:** Unchained

**Genre:** 2D Platformer

**Platform:** PC (Unity Engine)

**Game Summary:**
This is a 2D platformer where the player navigates through levels using movement, jumping, and a grappling mechanic. The goal is to reach the end of each level while avoiding hazards and minimizing deaths.

---

## 2. Core Gameplay

### Player Abilities

* Move left/right
* Jump
* Sprint (hold Shift)
* Grapple to specific surfaces

### Objective

* Reach the end of the level
* Press **E** to proceed to the next level

### Failure Condition

* Player touches a "Respawn" object → death
* Player either:

  * Respawns at checkpoint OR
  * Reloads the scene (depending on settings)

---

## 3. Controls

| Action   | Input               |
| -------- | ------------------- |
| Move     | A / D or Arrow Keys |
| Jump     | Space               |
| Sprint   | Left Shift          |
| Grapple  | Left Mouse Click    |
| Continue | E                   |

---

## 4. Systems Breakdown

### 4.1 Player Movement

* Uses Rigidbody2D physics
* Horizontal movement controlled by input
* Jump only when grounded
* Sprint temporarily doubles speed

### 4.2 Input System

* Uses event-based input (UnityEvents)
* Separates input from movement logic
* Sends:

  * Movement direction
  * Jump command

### 4.3 Grappling System

* Raycast from mouse position
* Attaches to objects in a specific layer
* Uses DistanceJoint2D for swinging
* LineRenderer displays rope

### 4.4 Respawn System

* Tracks number of deaths
* Displays death counter (UI)
* Two modes:

  * Scene reload
  * Checkpoint respawn

### 4.5 Level Progression

* Trigger-based finish zone
* Player presses **E** to load next scene

### 4.6 UI System

* Death counter using TextMeshPro
* Menu buttons for:

  * Start
  * Restart
  * Exit

---

## 5. Scene Structure

### Scenes:

* Start Menu
* Level 1 (lvl1)
* Additional levels (in progress)

---

## 6. Technical Details

### Engine

* Unity (2D)

### Key Components Used

* Rigidbody2D
* DistanceJoint2D
* LineRenderer
* UnityEvents
* SceneManager

---

## 7. Future Improvements

* Add animations
* Sound effects (jump, grapple, death)
* UI polish (menus, transitions)
* Checkpoint system improvements
* Grapple enhancements (swing physics, limits)
* Level design variety

---

## 8. Notes

* Uses both old and new input systems (can be unified later)
* Death counter persists unless manually reset

---

## 9. Credits

**Developer:** Sean Neerings

**Engine:** Unity

---

## 10. Version

**Current Version:** 0.1 Prototype

---

*End of Document*
