using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model.Components.Buttons;
using Tetris.Model.States;

namespace Tetris.Model.StateFactories
{
    // The client know which GameState to create, but don't need to know how to create them
    public interface IGameStateFactory  // separates/encapsulates/abstracts the creation process of GameState from logic 
    {
        public GameState Create(GameModel gameModel);
        public List<Button> CreateButton();
    }
}
