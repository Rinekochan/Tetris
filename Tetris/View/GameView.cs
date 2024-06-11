using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;
using Tetris.Model;
using Tetris.View.Drawers;
using Tetris.View.StaticFactories;

namespace Tetris.View
{
    public class GameView : IEventListener //  This class represents the Game View in MVC architecture, it knows what drawer need to be used to draw.
    {
        private EventManager _eventManager;
        private GameModel _gameModel;
        private Drawer _drawer;

        public GameView(GameModel gameModel, EventManager eventManager)
        {
            _eventManager = eventManager;
            _eventManager.Attach(this);
            _gameModel = gameModel;
            _drawer = DrawerFactory.Create(State.Menu, _gameModel.Game.GameMode);
        }

        public void Update(GameEvent e)
        {
            Enum.TryParse(e.GetMessage()[0], out Event eventType);
            switch (eventType)
            {
                case Event.Tick:
                    Draw();
                    break;
                case Event.Initialize: // The GameView will be initialized when receives Initialize Event
                    Initialize();
                    break;
                case Event.StateChange: // The drawer of GameView will changes when receives State Change Event
                    Enum.TryParse(e.GetMessage()[1], out State state);
                    _drawer = DrawerFactory.Create(state, _gameModel.Game.GameMode); // Delegates the drawer creation process to factory
                    break;
            }
        }

        public void Draw() // Use the current drawer to draw
        {
            _drawer.Draw(_gameModel);
        }

        private void Initialize() // Load font in the initialize event
        {
            SplashKit.LoadFont("Retro", "ARCADECLASSIC.TTF");
            SplashKit.LoadFont("RetroBold", "ARCADECLASSIC.TTF");
            SplashKit.SetFontStyle("RetroBold", FontStyle.BoldFont);
            SplashKit.LoadFont("Modern", "ProFontWindows.TTF");
            SplashKit.LoadFont("ModernBold", "ProFontWindows.TTF");
            SplashKit.SetFontStyle("ModernBold", FontStyle.BoldFont);
            SplashKit.LoadFont("HUNdin", "ModernHUNdin.TTF");
            SplashKit.LoadFont("HUNdinBold", "ModernHUNdin.TTF");
            SplashKit.SetFontStyle("HUNdinBold", FontStyle.BoldFont);
            SplashKit.LoadBitmap("SpaceBackground", "IngameBackground.jpg");
            SplashKit.LoadBitmap("MenuBackground", "MenuBackground.png");
        }
    }
}
