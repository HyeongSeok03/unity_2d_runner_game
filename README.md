# Unity 2D Runner Game

## Overview
This project is a side-scrolling 2D runner game developed with **Unity 6.2**, featuring modernized input handling, double-jump mechanics, collectible items, traps, and a checkpoint system.  

---

## Newly Implemented Features

### 1. Reworked Input System
The legacy `GetKeyDown`-based input handling was completely replaced with Unity’s **New Input System**.  
This transition provides more flexibility and scalability, allowing actions to be mapped through input actions and enabling controller or mobile support in the future.

### 2. Double Jump Mechanic
A full double jump system was implemented, including proper animation transitions between normal jump and double jump states.  
Players can now perform a second jump mid-air for extended movement control.

### 3. Life-Increasing Apple Item
A collectible **apple item** was added.  
When the player picks it up, one additional life is granted.  

### 4. Game Over on Falling
If the player falls off a cliff or below a defined threshold, the game triggers a **Game Over** state.  

### 5. Checkpoint System
A **checkpoint** system was implemented to record the player’s progress.  
When the player reaches a checkpoint, the respawn position is updated, ensuring that progress is not lost after death.

### 6. Damage Trap Mechanic
New **trap objects** were added in the map.  
When the player collides with a trap, one life is lost.

---

## Development Challenges
Transitioning to the **New Input System** was one of the most challenging aspects of this project.  
Adapting existing logic to the new event-based input model required restructuring several core systems, including jump handling and movement logic.  

Implementing the **double jump animation transitions** without unexpected bugs also proved difficult.  
Managing multiple animation states while maintaining responsive controls required careful synchronization between the animator parameters and game logic.  

Additionally, achieving proper **level balance**—so that the map felt fun yet challenging—took significant trial and error.  
Finding the right difficulty curve and positioning traps, checkpoints, and collectibles required continuous playtesting and fine-tuning.

---

## Controls
The following controls are currently implemented in the game:

| Action | Key | Description |
|--------|-----|-------------|
| Move Left / Right | **A / D** or **← / →** | Move the player horizontally |
| Jump | **Space** | Perform a jump |
| Double Jump | **Space** (in air) | Perform a second jump while in mid-air |

---

## Project Structure and Build Instructions

The source code is located in the following directory: `Assets/Scripts/`

To run the game, download the build folder located in: `Assets/Build/`

Then, execute the build file inside that folder to start the game.

---

## Assets and Licenses

All sprite assets used in this project come from the **Pixel Adventure 1** package, which is freely available on the Unity Asset Store.  
The asset follows the **Standard Unity Asset Store EULA**.

The code written for this project is released under the **MIT License**.

---
