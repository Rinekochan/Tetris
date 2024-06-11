using System;
using SplashKitSDK;
using Tetris.Controller;
using Tetris.View;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model;
using Tetris.Model.States;

namespace Tetris
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Tetris", 1280, 720);
            EventManager eventManager = new EventManager();
            // The resources folders like fonts, music, images, and json file is located in \bin\Debug\net8.0

            GameInputProcessor inputProcessor = new GameInputProcessor(eventManager);
            GameAudioProcessor audioProcessor = new GameAudioProcessor(eventManager);

            GameModel gameModel = new GameModel(eventManager);
            GameView gameView = new GameView(gameModel, eventManager);
            GameController gameController = new GameController(gameModel, eventManager);

            SplashKit.RegisterCallbackOnKeyTyped(inputProcessor.Listening); // This is for raw keyboard input listener.

            eventManager.Post(new GameEvent(Event.Initialize)); // Initialize any classes that need to load resources 
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                eventManager.Post(new GameEvent(Event.Tick)); // Notify a game loop event to all listeners
                SplashKit.RefreshScreen(60); // Refresh screen at 60 fps
            } while (!window.CloseRequested && gameModel.GameRunning);
        }      
    }
}
