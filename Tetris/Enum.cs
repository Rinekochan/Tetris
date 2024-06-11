using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris // This file is used to store program enumeration
{
    // Mode enumeration
    public enum Mode
    {
        Classic,
        NES,
        FortyLines,
        Blitz
    }

    // State enumeration
    public enum State
    {
        NotInitialized,
        Menu,
        Help,
        Ingame,
        PauseMenu,
        GameOver
    }

    // Event enumeration
    public enum Event
    {
        Tick,
        Initialize,
        StateChange,
        QuitGame,
        NewGame,
        ReturnToMenu,
        PauseGame,
        RestartGame,
        ResumeGame,
        OpenHelp,
        SaveScore,
        MouseInput,
        KeyboardInput,
        TetriminoInteraction,
        PlaceTetrimino,
        ClearLine,
    }
}
