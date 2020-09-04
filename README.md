# Cloaked
### A library built on MonoGame designed to make building 2D games easy, fun, and modular.

### This project is in its infancy. Stay tuned for updates.

## Introduction
Cloaked is a minimilist, code oriented library that takes the hassle out of building games from scratch. Cloaked handles all the boiler plate logic for you so that you can focus on writing code that is specific to your game.

Cloaked makes writing your game easier in the following ways:
- Takes responsibility for the architecture of your core game logic, so you don't have to worry about how to implement complicated, yet common parts of a game such as input handling, triggers, sprite animations, context switching, and more.
- Provides an easy to use API without forcing you into prescriptive design patterns or naming conventions.
- Leaves you completely free to use other libraries such as physics engines, etc. Cloaked doesn't assume that one size fits all, and all the critical code will still be written by you. Cloaked works mostly by you giving it callbacks to call at appropriate times or extending abstract classes and overriding methods. 
- Uses a stateful game mindset, which lends itself to good OOD principles by coupling state and behavior together, leading to more encapsulated and understandable code.
- Uses a highly modular component system which allows you to pick and choose what systems/ features you want to use for different situations.
- Is highly extensible, allowing you to easily extend and customize functionality for your own needs.

### Completed Features
- Game State Management
- Game Context Switching
- Pub/Sub Events and Trigger System
- Timed Effect System
- Keyboard Input System
- Sprite Rendering System
- Sprite Animation System
- Texture Management
- Basic 2D Camera

### Feature Road Map
- UI System
- Audio System
- Mouse and Game Pad Input System
- Unified/Abstracted Input System
- Texture Atlas System
- Debugging Features
- Much, much, more

### Future Plans
Cloaked will never be a game engine by itself. However, a lot of separate pieces of great functionality could be built to work synergistically with Cloaked. For example, a 2D level editor or a physics engine is something that could be built in the future to work with Cloaked, but they would be a separate project that you'd have to include in your game explicitly. The goal for this project is to provide functionality with as few constraints as possible. One day, if enough projects get built to work alongside this one, it could form a suite of libraries that could reach the level of a game engine all together, but that's a long ways off.

Adding 3D support would be a great addition, however that would probably become it's own project as well in order to preserve the simplicity and compactness of this one intact.

## Project Setup (for contributing)

### Prerequisites
- Visual Studio Code (Visual Studio 2019 will work, but requires a different setup process)
- Git
- [.NET Core SDK](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31)


### Setup
- Clone this repo into your desired home for the project on your machine.
- Open the project folder in VS Code.
- Open a new terminal and run `dotnet restore` to install dependencies.
- In the terminal, run `dotnet build` to make sure the project builds.

