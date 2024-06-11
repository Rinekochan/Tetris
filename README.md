# Tetris Game

### Simple Tetris Game in C#

This program is created in C# using SplashKit library by Viet Hoang Pham. This is my project for an unit during my undergraduate program. 

### Tetris Functionalities (More details in reports folder)
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
* **Main Menu** where the player can choose the game mode they want to play with different game rules. They can also click on the Help button to open Help state.
* **Help** where the player can read about the controls, shortcuts, and game modes configurations/rules in the game.
* **Ingame** where the player plays Tetris (the game logic).
* **Pause Menu** where the player can pause the current game. They can either continue their current game, restart to have a new one, or return to the Main Menu state.
* **Game Over** where the player can have a look at their top 5 scores/times of each game mode they are playing. They can type their name to save their current scores in this state.

### Design Patterns (More details in reports folder)
1. **Observer**
2. **State**
3. **Decorator**
4. **Factory Methods**
5. **Builder**
6. **Command**
7. **Strategy**
8. **Singleton**
9. **Mediator**
### 
Videos 
[6 mins video with talking](https://drive.google.com/file/d/1GK1tSVRb80M0J5ckxRpsm1i2wdEY3yGN/view?usp=sharing)
