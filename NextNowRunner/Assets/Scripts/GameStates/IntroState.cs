using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class IntroState : GameState
{

    public IntroState()
    {

    }


    public override void Enter()
    {
        //Create the Object managers here
        GameObjectManager.Kickstart();

    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        
    }
}
