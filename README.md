# Tetris Game

### Simple Tetris Game in C#

This program is created in C# using SplashKit library by Viet Hoang Pham. This is my project for an unit during my undergraduate program. 

### Tetris Functionalities
The player will be presented with a grid-based game board where Tetriminos fall from the top of the screen.
- **4 game modes in the game:** Classic, NES, 40 Lines, and Blitz with different game rules.
- **The queue** is introduced to show the player what are the next pieces. The amount of queued Tetriminos being displayed is based on game mode (1 in Classic, NES; 5 in 40 Lines, Blitz).
- **2 queue randomness algorithms:** The first one is completely random, where a type of Tetrimino has the chance of being created 5 times in a row. The second one is 7-bag random, where a type of Tetrimino can only appear once in every 7 turns (the algorithm randoms the permutations of 7 Tetriminoes instead of the Tetriminoes themselves).
- **The randomness algorithm is chosen based on the game mode**: In Classic and NES, the game chooses completely random, while the game chooses 7-bag random algorithm in Blitz and 40-Lines game modes.
- **The player can also hold a Tetrimino** in Blitz and 40-Lines game mode, which means that when the current Tetrimino is not what they want, they can always hold/swap that Tetrimino.
- Depends on each game mode, the objective of the game is that you will get points for the number of lines cleared (in Classic, NES, Blitz) based on the number of lines cleared, or have the fastest time possible to clear 40 lines (in 40 lines).
- Normally, the game ends when the tetrominoes stack up to the top of the playing field without any space left for new pieces. But it can also end based on some game modes such as when the game time reaches 2 minutes in Blitz or clears 40 Lines in 40 Lines
- The player can save their scores with their name, which will be recorded into the BestScore.json file. The recorded scores are always sorted before being saved and rewritten.
- The best score/fastest time is always displayed during the game. It’s loaded from the mentioned JSON file.
- The game also plays background music, and it changes depending on the current state.
- The game has 5 main states with different displays and controls:
    - **Main Menu** where the player can choose the game mode they want to play with different game rules. They can also click on the Help button to open Help state.
    - **Help** where the player can read about the controls, shortcuts, and game modes configurations/rules in the game.
    - **Ingame** where the player plays Tetris (the game logic).
    - **Pause Menu** where the player can pause the current game. They can either continue their current game, restart to have a new one, or return to the Main Menu state.
    - **Game Over** where the player can have a look at their top 5 scores/times of each game mode they are playing. They can type their name to save their current scores in this state.

### Design Patterns
1. **Observer**
- Tetris Custom Program represents the MVC architecture, where the Observer pattern is used to implement an event-driven architecture, decoupling the Model, View, and Controller components. The Event Manager (Observer) acts as the "middle-man" to handle the communication between these components, where one component reacts and changes based on the game events posted by other components instead of directly depending on each other. Changes in one component do not require modifications in others since the listeners update based on the game events, making the system easier to maintain and extend. New listeners like Game Logic can also be added at runtime, by providing a queue of Attach, Detach, and Game Events to avoid concurrent problems.
2. **State**
- The Tetris game states are modeled using the State design pattern to handle different game states such as Main Menu, Help, Ingame, Pause Menu, and Game Over. It allows for clean separation of state-specific behavior and easy transitions between different game states. Each state has distinct behaviors and transitions that can be encapsulated within separate state classes: Menu State can transition to Help State or Ingame State, and Ingame State can transition to Pause Menu and Game Over State. Pause Menu and Game Over state can transition to Ingame State or Menu State depending on the game events.
3. **Decorator**
- In the Tetris Custom Program, the Decorator pattern is used to extend the functionalities of the GameLogic class, such as implementing different game-ending conditions (e.g., a Blitz game mode that ends after 2 minutes or a 40 Lines game mode that ends after clearing 40 lines) and adding the ability to hold Tetriminos.
4. **Factory Methods**
- The Factory Method pattern is used to create different game states with complex configurations in the Tetris Custom Program. Each state (Main Menu, Help, Ingame, Pause Menu, Game Over) has distinct information like game buttons.
5. **Builder**
- It provides a way to construct a complex object by specifying its type and content through a construction process. The Builder pattern is used to create immutable game buttons. These buttons have a range of properties such as size, color, border size, border color, and text, making the telescoping constructor pattern cumbersome and error-prone.
6. **Command**
- In the Tetris Custom Program, the Command pattern is used to handle keyboard and mouse inputs. Each command corresponds to a specific game action, and the Event Manager (following the mentioned Observer pattern) posts different game events based on these commands. The Command pattern decouples the input handling from the game logic. The GameController does not need to know how each command is executed; it only needs to invoke the command.
7. **Strategy**
- In the Tetris Custom Program, the Strategy pattern is used to implement different queue random algorithms, and various display strategies for the queue, score, hold, extra display in the Ingame Drawer, and top five display in the Game Over Drawer. This setup ensures that different algorithms and display formats can be easily interchanged and extended, resulting in a more modular and easily extendable functionality. 
8. **Singleton**
- The Singleton pattern is used for the BestScoreManager class. This class is responsible for loading the best scores from a JSON file and saving the player's score to the JSON file. The Singleton pattern ensures that there is only one instance of BestScoreManager throughout the game, coordinating all actions related to score management.
9. **Mediator**
- The GameLogic class in the Tetris custom program acts as a mediator that decouples the EventManager from Grid, Tetrimino, ScoreProcessor, QueueProcessor, LevelProcessor, and TickProcessor. The GameLogic class centralizes interactions between various components as it receives events from the EventManager and decides how to process them with the grid, Tetrimino, score, queue, level, and tick processors. Moreover, the components themselves don’t need to directly depend on each other like Grid doesn’t need to know anything about Tetrimino and vice versa. The mediator pattern also simplifies interactions between objects, reducing potential errors and dependencies.
  
### Videos 
[6 mins video](https://drive.google.com/file/d/1GK1tSVRb80M0J5ckxRpsm1i2wdEY3yGN/view?usp=sharing)
