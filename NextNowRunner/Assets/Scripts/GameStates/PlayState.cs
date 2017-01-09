using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayState : GameState
{

    public PlayState() : base()
    {

    }

    public override void Enter()
    {
        //Set up the game
        GameObjectManager.Activate();
        //UI Manager
        UIManager.SwitchToGame();
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        //Clean up scene
        GameObjectManager.Deactivate();
        //UIManager
        UIManager.SwitchToIntro();
    }
}
