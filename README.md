# SaveLoadService

## Overview

This project showcases the implementation of a flexible and scalable **Save/Load system**. It supports saving player progress to **PlayerPrefs** and **Yandex Games** cloud storage. It also showcases the use of **design patterns** such as **State Machine** and **Abstract Factory**.

---

## Key Highlights

- **Asynchronous loading** support for Yandex Games cloud saving
- **Modular and scalable architecture** for easy maintenance and expansion
- Codebase using **design patterns** and **clean code** principles

---

## Project Structure

SaveLoadService/
│
├── Data/
│ 	├── PlayerProgress.cs 	# Stores key gameplay data
│	└── SavesYG.cs 			# Extends Yandex Games Plugin save system to support custom data
│
├── Factory/
│ 	├── IGameFactory.cs
│	├── GameFactory.cs 		 # Handles object creation
│ 	├── IStateFactory.cs
│	└── StateFactory.cs		 # Creates and manage game states
│
├── GameStateMachine/
│ 	├── IStateMachine.cs
│	└── GameStateMachine.cs  # Manages transitions between game states
│
├── GameStates/
│   ├── IState.cs            # Defines basic states that can run initialization logic, accept a payload on entry, and perform cleanup or transitions on exit
│   ├── LoadProgressState.cs # A game state responsible for loading or initializing player progress and transitioning to the next state upon completion
│   └── MockNextState.cs     # Any next state
│
├── SaveComponent/
│   └── SaveTrigger.cs       # MonoBehavior component for saving player progress when the player enters the collider area on a scene
│
├── Services/
│   ├── IService.cs          			  # A base marker interface used to identify service classes
│   ├── PersistentProgress/
│   │   ├── ISavedProgressReader.cs       # An interface for loading player progress data from a given PlayerProgress instance with read-only access
│   │   ├── ISavedProgressWriter.cs  	   # An interface for updating and reading player progress data from a given PlayerProgress instance
│   │   ├── IPersistentProgressService.cs # An interface for providing access to the current player progress for reading and updating across the game
│   │   └── PersistentProgressService.cs  # Provide a reference to the player progress
│   ├── SaveLoad/            
│   │   ├── ISaveLoadService.cs           # Defines basic operations for saving, loading, and resetting player progress
│   │   ├── SaveLoadService.cs  		      # Handles saving, loading, and resetting player progress using PlayerPrefs and synchronizes progress data across game components
│   │   ├── **IAsyncSaveLoadService.cs**      # Defines an interface for asynchronous loading and saving of player progress, and load completion callback
└── └── └── **YGAsyncSaveLoadService.cs**     # Provides an asynchronous implementation of player progress saving and loading for the Yandex Games platform, integrating with YG SDK

---

## Systems and Features

1. **SaveLoadService**:
   - `SaveLoadService`
   - `YGAsyncSaveLoadService`

2. **PersistentProgressService**:
   - Centralized access to player progress data

3. **Factory**:
   - `GameFactory` handles object creation in the game scene
   - `StateFactory` handles states of the game

4. **GameStateMachine**:
   - `GameStateMachine` manages game states

5. **Data**:
   - `PlayerProgress` stores user data relevant to gameplay progression.
   - `SavesYG` extends Yandex Games Plugin save system to support custom data

---

## Patterns Used

- **State Machine**:
  - `GameStateMachine`

- **Abstract Factory**:
  - `GameFactory`
  - `StateFactory`

- **Dependency Injection**:
  - Inject dependencies via a constructor (or a special `Construct()` method for MonoBehaviour classes)

---

## Commit Descriptions

|-----------|----------------------------------------------------------------|
| Name      | Description                                                    |
|-----------|----------------------------------------------------------------|
| init	   | Start a project/task						             		        |
| build     | Project build or changes in external dependencies              |
| sec       | Security and vulnerability fixes                               |
| ci        | CI configuration and script updates                            |
| docs      | Documentation updates                                          |
| feat      | Adding new functionality                                       |
| fix       | Bug fixes                                                      |
| perf      | Changes aimed at improving performance                         |
| refactor  | Code refactoring without fixing bugs or adding new features    |
| revert    | Reverting previous commits                                     |
| style     | Code style fixes (tabs, indents, dots, commas, etc.)           |
| test      | Adding tests                                                   |
| chore     | Changes to the build process or auxiliary tools and libraries  |
|-----------|----------------------------------------------------------------|
