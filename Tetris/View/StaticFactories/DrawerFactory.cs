using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.View.Drawers;
using Tetris.View.Drawers.GameOverDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.ExtraIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.HoldIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.QueueIngameDrawStrategies;
using Tetris.View.Drawers.IngameDrawStrategies.RecordIngameDrawStrategies;

namespace Tetris.View.StaticFactories
{
    public static class DrawerFactory // seperates/encapsulates the creation process of Drawer in each state
    {
        public static Drawer Create(State state, Mode mode)
        {
            switch (state)
            {
                case State.Menu: // If current state is menu, current Drawer is MenuDrawer
                    return new MenuDrawer();
                case State.Help: // If current state is help, current Drawer is HelpDrawer
                    return new HelpDrawer();
                case State.Ingame: // If current state is ingame, current Drawer is IngameDrawer
                    RecordIngameDrawStrategy recordIngameDraw = RecordIngameDrawFactory.Create(mode);
                    IQueueIngameDrawStrategy queueIngameDraw = QueueIngameDrawFactory.Create(mode);
                    IHoldIngameDrawStrategy holdIngameDraw = HoldIngameDrawFactory.Create(mode);
                    IExtraIngameDrawStrategy extraIngameDraw = ExtraIngameDrawFactory.Create(mode);
                    return new IngameDrawer(recordIngameDraw, queueIngameDraw, holdIngameDraw, extraIngameDraw);
                case State.PauseMenu: // If current state is pause, current Drawer is PauseMenuDrawer
                    return new PauseMenuDrawer();
                case State.GameOver: // If current state is game over, current Drawer is GameOverDrawer
                    BestRecordGameOverDrawStrategy bestRecordGameOverDraw = BestRecordGameOverDrawFactory.Create(mode);
                    return new GameOverDrawer(bestRecordGameOverDraw);
                default:
                    throw new Exception($"I don't know what state is {state} to create Drawer");
            }
        }

    }
}
