# Unity Platformer

A feature-rich 2D platformer game built in Unity, showcasing advanced movement mechanics and interactive gameplay elements.

## 🎮 Demo Video

[![Unity Platformer Demo](https://img.youtube.com/vi/LGW8in1oPxQ/0.jpg)](https://www.youtube.com/watch?v=LGW8in1oPxQ&list=PLKz7QOwPaa35za3Q2WB6QacrwIFppwwSh&index=4)

*Click the image above to watch the gameplay demo*

## ✨ Features

### Core Movement Mechanics
- **Advanced Player Movement**: Smooth walking, jumping, and physics-based controls
- **Wall Jumping**: Dynamic wall jump mechanics for enhanced traversal
- **Dash System**: Directional dashing with visual feedback and cooldown management
- **Gravity Control**: Toggleable gravity mechanics for unique puzzle elements

### Interactive Elements
- **Collectibles System**: 
  - Regular coins for scoring
  - Mega coins for bonus points
  - Dash crystals that restore dash ability
- **Umbrella Mechanics**: Slow-fall gameplay with pickup/drop functionality
- **Portal System**: 
  - Standard two-way portals
  - One-entrance portal pairs for advanced level design

### Dynamic Platforms
- **Moving Platforms**: Auto-moving platforms with customizable waypoints
- **Bounce Pads**: Directional bounce mechanics based on player position
- **Disappearing Platforms**: Timed platforms that vanish after collision
- **Lethal Hazards**: Deadly platforms and obstacles
- **Combination Platforms**: Moving + bouncing, moving + disappearing variants

### Game Systems
- **Checkpoint System**: Save progress at designated points
- **Life Management**: Health system with respawn mechanics
- **Coin Counter**: Real-time score tracking
- **Respawn System**: Seamless player respawn at checkpoints

## 🎯 Gameplay Mechanics

### Movement Controls
- **Walking**: Smooth horizontal movement with physics-based acceleration
- **Jumping**: Ground and wall jumping with variable height
- **Dashing**: High-speed directional movement (requires dash crystals)
- **Wall Interaction**: Stick to walls and perform wall jumps

### Special Features
- **Smart Collision Detection**: Precise collision handling for all interactive elements
- **Physics Integration**: Realistic physics with custom materials
- **Visual Feedback**: Dynamic sprite changes based on player state (dash availability)
- **Audio Integration**: Sound effects for interactions and collections

## 🏗️ Technical Architecture

### Core Scripts
- `PlayerMovement.cs`: Complete player controller with all movement mechanics
- `PlayerRespawn.cs`: Handles death and respawn logic
- `AutoMovement.cs`: Manages moving platform behaviors
- `BouncePad.cs`: Implements directional bouncing mechanics
- `CarryPlayer.cs`: Platform-player attachment system

### Interactive Components
- `Coin.cs` & `CoinCounter.cs`: Collectible and scoring system
- `DashCrystal.cs`: Dash ability restoration
- `Umbrella.cs`: Slow-fall mechanics with user control
- `Checkpoint.cs`: Progress saving system
- `Lethal.cs`: Hazard and death mechanics

### Platform Behaviors
- `DisappearOnCollision.cs`: Timed platform destruction
- `GravityToggle.cs`: Environmental gravity manipulation
- Portal systems for teleportation mechanics

## 🛠️ Development Details

### Built With
- **Unity 2D**: Complete 2D game development framework
- **C# Scripting**: All game logic and mechanics
- **Physics2D**: Unity's 2D physics system for realistic interactions
- **TextMesh Pro**: UI and text rendering

### Project Structure
```
Assets/
├── Scripts/          # All game logic and mechanics
├── Prefabs/         # Reusable game objects and platforms
├── Sprites/         # Game artwork and textures  
├── Scenes/          # Level layouts and game scenes
├── Audio/           # Sound effects and music
└── PhysicsMaterials/# Custom physics materials
```

### Key Features Implementation
- **Modular Design**: Reusable prefab system for easy level creation
- **Component-Based Architecture**: Clean separation of concerns
- **Extensible Mechanics**: Easy to add new platform types and interactions
- **Performance Optimized**: Efficient collision detection and physics handling

## 🚀 Getting Started

1. **Prerequisites**: Unity 2019.4 LTS or later
2. **Clone/Download** the project
3. **Open in Unity**: Import the project folder
4. **Play**: Open any scene and hit play to start testing

## 🎮 Controls

- **Arrow Keys / WASD**: Move left/right
- **Space**: Jump (ground or wall jump)
- **Left Shift**: Dash (when available)
- **Left Control**: Drop umbrella (when holding)

## 🔧 Customization

The game features highly customizable mechanics:
- Adjust movement forces and speeds in `PlayerMovement.cs`
- Modify platform behaviors through inspector variables
- Create new platform combinations using existing components
- Design levels using the comprehensive prefab library

## 📈 Future Enhancements

- Level editor integration
- More collectible types
- Additional movement mechanics
- Enhanced visual effects
- Multiplayer support potential

---

*This project demonstrates advanced Unity 2D development techniques including physics-based movement, modular architecture, and complex gameplay systems.*