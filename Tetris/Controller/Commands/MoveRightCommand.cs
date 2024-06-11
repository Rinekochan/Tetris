﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.GameEventManager;
using Tetris.GameEventManager.GameEvents;

namespace Tetris.Controller.Commands
{
    public class MoveRightCommand : GameCommand // This command calls the event to move the tetrimino right
    {
        public MoveRightCommand() : base(new string[] { "RightKey" }) { } // Player presses arrow right key to use this command
        public override void Execute(EventManager eventManager)
        {
            eventManager.Post(new TetriminoInteractionEvent("Right"));
        }
    }
}
