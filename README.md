Sync Dash - Unity 3D Project(A Hypercasual Game)
**Objective**
Create a simple hyper-casual game where the screen is divided into two halves:
Right Side → The player controls their character.
Left Side → The ghost player mirrors the player's actions in real-time, simulating network syncing locally.

This Project implies real-time state synchronization, shader & particle effects, and performance optimization without an actual multiplayer server.

**Project Overview
Title: Sync Dash**

**Concept:**
A glowing cube moves forward automatically. The player taps to jump and avoid obstacles while collecting glowing orbs. The left side of the screen mirrors the player’s movements in real-time, simulating a networked opponent.


1. Core Gameplay (Strong Logic)
Player-Controlled Cube:
The cube moves forward automatically on the right side of the screen.
The player taps to jump and avoid obstacles.
The player collects glowing orbs for points.

Left Side Sync:
The left side mirrors the player’s movements in real-time.
The player sends data to the left-side character as if it were a networked multiplayer opponent.

Game Progression:
The game speed increases over time, making the challenge progressively harder.
Game has a score system based on distance traveled and number of collected orbs.

2. Real-Time State Syncing (Simulating Multiplayer Locally)
Syncing the Player Actions:
The left side mimics the player's actions in real-time (jump, movement, orb collection, obstacle collision).
There is a configurable delay to simulate a network sync.

Smooth interpolation ensures the left-side movement is not jittery.

Data Structures used for Syncing:
Queue to sync player actions in real time.

3. UI & Game Flow
Main Menu:
Display a "Start" button to begin the game.
Display an "Exit" button to quit the game.

Game Over Screen:
Show a game over screen with options to "Restart" or go to the "Main Menu."

Score Display:
Display the current score at the top of the screen during gameplay.

4. Performance Optimization
Object Pooling:
Certain set of objects are pooled and they are reused through-out the project

Optimize Sync Mechanism:
Optimize the player syncing mechanism to minimize frame drops or lag.

Build Size:
Build Size is 26.9 mb.


Orb Collection Effect:
A particle effect get's triggered when orbs are collected

Crashing Effects:
When the player crashes, Screen shakes and a blast effect is generated

Getting Started
Prerequisites
Unity 2020.3 or higher.


Setup Instructions
Clone or download the project repository:

Copy
git clone https://github.com/yourusername/sync-dash.git
Open the project in Unity:
Open Unity Hub, and then open the Sync Dash project folder.

To play the game:
Press the Play button in the Unity Editor.

The game will start with the main menu. Click Start to begin playing.

Structure of the Project
Folders:
Assets/Scenes: Contains all the game scenes (Main Menu, Gameplay, Game Over).
Assets/Scripts: Contains all the C# scripts that control the gameplay, player actions, syncing, UI, etc.
Assets/Shaders: Contains all custom shaders (e.g., glowing, dissolve, etc.).
Assets/Prefabs: Contains all game objects like obstacles, player cubes, and orbs.
Assets/Textures: Contains textures for the player cube and other game assets.

